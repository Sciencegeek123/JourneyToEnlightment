using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyIdle : EnemyState
{

    // Use this for initialization
    public override void Start () {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(transform.position);
    }

    // Update is called once per frame
    public override void Update () {
		// Chill out
	}

    // Basic Enemy States
    // Transition exclusion rules in these
    public override void ToIdle(BaseEnemy myEnemy)
    {
        // Idle from idle?  get out of here
    }

    public override void ToRoam(BaseEnemy myEnemy)
    {
        base.ToRoam(myEnemy);
    }

    public override void ToChase(BaseEnemy myEnemy)
    {
        base.ToChase(myEnemy);
    }

    public override void ToAttack(BaseEnemy myEnemy)
    {
        base.ToAttack(myEnemy);
    }

    // Responses to Bells
    // Super attack
    public override void ToFrenzy(BaseEnemy myEnemy)
    {
        base.ToFrenzy(myEnemy);
    }

    // stop attack; wander around
    public override void ToConfuse(BaseEnemy myEnemy)
    {
        base.ToConfuse(myEnemy);
    }

    // go nice NPC
    public override void ToSubdue(BaseEnemy myEnemy)
    {
        base.ToSubdue(myEnemy);
    }
}
