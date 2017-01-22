using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySubdue : EnemyState {
    float TimeSubdued = 0.0f;
    public float SubdueDuration = 3.0f;

    // Use this for initialization
    public override void Start () {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(transform.position);
        TimeSubdued = 0.0f;
    }

    // Update is called once per frame
    public override void Update () {
        TimeSubdued += Time.deltaTime;
        if (TimeSubdued >= SubdueDuration)
        {
            ToIdle(Enemy);
        }
	}

    // Basic Enemy States
    // To Idle from Subdue allowed
    public override void ToIdle(BaseEnemy myEnemy)
    {
        base.ToIdle(myEnemy);
    }

    public override void ToRoam(BaseEnemy myEnemy)
    {
        // Conditions to prevent idle to roam

    }

    public override void ToChase(BaseEnemy myEnemy)
    {
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
