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
        base.Start();
        Player = Enemy.Player;
        agent = GetComponent<NavMeshAgent>();
        agent.speed *= MovementMultiplier;
        agent.angularSpeed *= MovementMultiplier;
        agent.SetDestination(Player.transform.position);
        anim.SetBool("Frenzy", true);
    }

    public override void Outro()
    {
        anim.SetBool("Frenzy", false);
        agent.speed /= MovementMultiplier;
        agent.angularSpeed /= MovementMultiplier;
        base.Outro();
    }

    // Update is called once per frame
    public override void Update () {
        TimeInFrenzy += Time.deltaTime;
        if (TimeInFrenzy >= MaxFrenzyTime)
        {
            ToIdle(Enemy);
        }
        else
        {
            agent.SetDestination(Player.transform.position);
        }

    }


    // Basic Enemy States
    public override void ToIdle(BaseEnemy myEnemy)
    {
        base.ToIdle(myEnemy);
    }

    public override void ToRoam(BaseEnemy myEnemy)
    {
    }

    public override void ToChase(BaseEnemy myEnemy)
    {
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
