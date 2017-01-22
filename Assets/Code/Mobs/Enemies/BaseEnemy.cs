using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {

    [SerializeField] ParticleSystem OptionalParticleSystem;
    [SerializeField] AudioSource OptionalAudioSource;
    // Bell-Enemy Interface
    public void Frenzy()
    {
        CurrentState.ToFrenzy(this);
    }
    public void Confuse()
    {
        CurrentState.ToConfuse(this);
    }
    public void Subdue()
    {
        CurrentState.ToSubdue(this);
    }

    public float MinDistanceToChase = 1.0f; // [m]
    public float MaxDistanceToChase = 5.0f;
    public float MinDistanceToAttack = 0.3f; // [m]
    public float MaxIdleTime = 1.0f; // [s]
    public float MaxRoamTime = 4.0f; // [s]
    public float AttackCooldownTime = 2.0f;

    public float SoundCooldown = 5.0f;
    public float lastSoundStart;

    public void SetState(EnemyState nextState)
    { 
        if(nextState != null)
        {
            if (CurrentState != null)
            {
                CurrentState.enabled = false;
            }
            CurrentState = nextState;
            CurrentState.Enemy = this;
            CurrentState.enabled = true;
            CurrentState.Start();
        }
    }

    public void RotateTowardVelocity()
    {
    }
    public float TimeRoaming;
    public float TimeIdling;
    public float TimeSinceAttack;

    public EnemyState CurrentState;
    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent agent { get; set; }

    // Use this for initialization
    public virtual void Start () {
        EnemyState tempState = null;
        tempState = GetComponent<EnemyIdle>();
        lastSoundStart = Random.Range(0,30);

        if (tempState != null)
        {
            SetState(tempState);
        }
        else
        {
            Debug.Log("Couldn't initialize enemy's first state.");
        }

        Player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	// Update is called once per frame
	public virtual void Update () {
        HandleStateInfo();

        if(Time.realtimeSinceStartup - lastSoundStart > SoundCooldown) {
            lastSoundStart = Time.realtimeSinceStartup;
            if(OptionalAudioSource != null) {
                OptionalAudioSource.Play();
            }
            if(OptionalParticleSystem != null) {
                OptionalParticleSystem.Play();
            }
        }
	}

    void HandleStateInfo()
    {
        Vector3 PlayerPosition = Player.transform.position;
        Vector3 MyPosition = transform.position;

        EnemyIdle tempIdle = CurrentState as EnemyIdle;
        EnemyRoam tempRoam = CurrentState as EnemyRoam;
        EnemyAttack tempAttack = CurrentState as EnemyAttack;
        EnemyChase tempChase = CurrentState as EnemyChase;

        if (tempIdle != null)
        {
            TimeIdling += Time.deltaTime;
        }
        else
        {
            TimeIdling = 0;
        }
        if (tempRoam != null)
        {
            TimeRoaming += Time.deltaTime;
        }
        else
        {
            TimeRoaming = 0;
        }
        if (tempAttack == null)
        {
            TimeSinceAttack += Time.deltaTime;
        }
        else
        {
            TimeSinceAttack = 0.0f;
        }

        Vector3 displacement = PlayerPosition - MyPosition;

        if (displacement.magnitude <= MinDistanceToAttack
                && TimeSinceAttack > AttackCooldownTime)
        {
            // Debug.Log("Attempting to Attack");
            Attack();
        }
        // if (plr-enemy).dist < engage distance
        // Chase();
        else if (displacement.magnitude <= MinDistanceToChase
            && displacement.magnitude > MinDistanceToAttack)
        {
            Chase();
        }

        // else if (idleTime> maxIdleTime)
        // Roam();
        else if (TimeIdling > MaxIdleTime
               || (displacement.magnitude >= MaxDistanceToChase
                   && tempChase != null))
        {
            //Debug.Log("Attempting To Roam");
            Roam();
        }
        // else if (roamingTime > maxroamTime)
        // Idle();
        else if (TimeRoaming > MaxRoamTime)
        {
            // Debug.Log("Attempting To Idle");
            Idle();
        }
    }

    // internal state changing
	void Idle()
	{
		CurrentState.ToIdle(this);
	}
	void Roam()
	{
		CurrentState.ToRoam(this);
	}
	void Chase()
	{
		CurrentState.ToChase(this);
	}
	void Attack()
	{
		CurrentState.ToAttack(this);
	}

}
