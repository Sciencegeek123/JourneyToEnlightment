using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {
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

    EnemyState CurrentState;
    GameObject Player;

    public float MinDistanceToChase = 1.0f; // [m]
    public float MinDistanceToAttack = 0.3f; // [m]
    public float MaxIdleTime = 1.0f; // [s]
    public float MaxRoamTime = 4.0f; // [s]

    float TimeRoaming;
    float TimeIdling;

	// Use this for initialization
	void Start () {
        CurrentState = new EnemyIdle();
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 PlayerPosition = Player.transform.position;
        Vector3 MyPosition = transform.position;

        EnemyIdle tempIdle = CurrentState as EnemyIdle;
        EnemyRoam tempRoam = CurrentState as EnemyRoam;
  
        if( tempIdle != null )
        {
            TimeIdling += Time.deltaTime;
        }
        else
        {
            TimeIdling = 0;
        }
        if( tempRoam != null )
        {
            TimeRoaming += Time.deltaTime;
        }
        else
        {
            TimeRoaming = 0;
        }


        // if (plr-enemy).dist < engage distance
        // Chase();
        if ( (PlayerPosition-MyPosition).magnitude < MinDistanceToChase )
        {
            Chase();
        }
        // if (plr-enemy).dist < attack distance
        // Attack();
        else if ( (PlayerPosition-MyPosition).magnitude < MinDistanceToAttack )
        {
            Attack();
        }
        // else if (roamingTime > maxroamTime)
        // Idle();
        else if ( TimeRoaming > MaxRoamTime )
        {
            Idle();
        }
        // else if (idleTime> maxIdleTime)
        // Roam();
        else if ( TimeIdling > MaxIdleTime )
        {
            Roam();
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
