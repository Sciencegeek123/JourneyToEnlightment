﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoam : EnemyState
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Basic Enemy States
    public override void ToIdle(BaseEnemy myEnemy)
    {
        // Idle from idle?  get out of here
    }

    public override void ToRoam(BaseEnemy myEnemy)
    {
        // Conditions to prevent idle to roam

    }

    public override void ToChase(BaseEnemy myEnemy)
    {
        //base.ToChase(myEnemy);
    }

    public override void ToAttack(BaseEnemy myEnemy)
    {

    }

    // Responses to Bells
    // Super attack
    public override void ToFrenzy(BaseEnemy myEnemy)
    {

    }

    // stop attack; wander around
    public override void ToConfuse(BaseEnemy myEnemy)
    {

    }

    // go nice NPC
    public override void ToSubdue(BaseEnemy myEnemy)
    {

    }
}