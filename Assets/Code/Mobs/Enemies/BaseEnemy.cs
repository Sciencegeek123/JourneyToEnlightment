using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {

	EnemyState CurrentState;

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
		CurrentState.ToIdle();
	}
	void Roam()
	{
		CurrentState.ToRoam();
	}
	void Chase()
	{
		CurrentState.ToChase();
	}
	void Attack()
	{
		CurrentState.ToAttack();
	}
	
    // For Bells to call
	public void Frenzy()
	{
		CurrentState.ToFrenzy();
	}
	public void Confuse()
	{
		CurrentState.ToConfuse();
	}
	public void Subdue()
	{
		CurrentState.ToSubdue();
	}

}
