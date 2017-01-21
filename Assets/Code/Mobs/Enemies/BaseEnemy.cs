using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {

	EnemyState CurrentState;

    public float MinDistanceToEngage = 1.0f; // [m]
    public float MinDistanceToAttack = 0.3f; // [m]
    public float MaxIdleTime = 1.0f; // [s]
    public float MaxRoamTime = 4.0f; // [s]

	// Use this for initialization
	void Start () {
        CurrentState = new EnemyIdle();
	}
	
	// Update is called once per frame
	void Update () {
		// if (plr-enemy).dist < engage distance
        // Chase();
        // else if (roamingTime > maxroamTime)
        // Idle();
        // else if (idleTime> maxIdleTime)
        // Roam();
        // if (plr-enemy).dist < attack distance
        // Attack();
	}

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
	
    // For Bells to call
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

}
