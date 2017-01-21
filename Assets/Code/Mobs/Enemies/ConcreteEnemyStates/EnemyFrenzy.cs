using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFrenzy : EnemyState
{
    float TimeInFrenzy = 0.0f;
    float MaxFrenzyTime = 5.0f;

    public float MovementMultiplier = 2.0f;
    NavMeshAgent agent;

    // Use this for initialization
    public override void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed *= MovementMultiplier;
        agent.angularSpeed *= MovementMultiplier;
        agent.SetDestination(Player.transform.position);
    }

    // Update is called once per frame
    public override void Update () {
        TimeInFrenzy += Time.deltaTime;
        if (TimeInFrenzy >= MaxFrenzyTime)
        {
            agent.speed /= MovementMultiplier;
            agent.angularSpeed /= MovementMultiplier;
            ToChase(Enemy);
        }
    }


    // Basic Enemy States
    public override void ToIdle(BaseEnemy myEnemy)
    {
        base.ToIdle(myEnemy);
    }

    public override void ToRoam(BaseEnemy myEnemy)
    {
        // Conditions to prevent idle to roam
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
