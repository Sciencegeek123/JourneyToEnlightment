using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyState{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Basic Enemy States
    public override void ToIdle()
    {
        base.ToIdle();
    }

    public override void ToRoam()
    {
        base.ToRoam();
    }

    public override void ToChase()
    {
        base.ToChase();
    }

    public override void ToAttack()
    {
        
    }

    // Responses to Bells
    // Super attack
    public override void ToFrenzy()
    {

    }

    // stop attack; wander around
    public override void ToConfuse()
    {

    }

    // go nice NPC
    public override void ToSubdue()
    {

    }
}
