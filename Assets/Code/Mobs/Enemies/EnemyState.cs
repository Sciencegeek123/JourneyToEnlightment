using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour {
    BaseEnemy myEnemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Basic Enemy States
    public virtual void ToIdle()
    {

    }

    public virtual void ToRoam()
    {

    }

    public virtual void ToChase()
    {

    }

    public virtual void ToAttack()
    {

    }

    // Responses to Bells
    // Super attack
    public virtual void ToFrenzy()
    {

    }

    // stop attack; wander around
    public virtual void ToConfuse()
    {

    }

    // go nice NPC
    public virtual void ToSubdue()
    {

    }

}
