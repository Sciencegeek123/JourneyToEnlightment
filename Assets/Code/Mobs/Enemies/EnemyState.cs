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
    public virtual void ToIdle(BaseEnemy myEnemy)
    {

    }

    public virtual void ToRoam(BaseEnemy myEnemy)
    {

    }

    public virtual void ToChase(BaseEnemy myEnemy)
    {

    }

    public virtual void ToAttack(BaseEnemy myEnemy)
    {

    }

    // Responses to Bells
    // Super attack
    public virtual void ToFrenzy(BaseEnemy myEnemy)
    {

    }

    // stop attack; wander around
    public virtual void ToConfuse(BaseEnemy myEnemy)
    {

    }

    // go nice NPC
    public virtual void ToSubdue(BaseEnemy myEnemy)
    {

    }

}
