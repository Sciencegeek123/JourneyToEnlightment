using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : EnemyState
{
    public UnityEngine.AI.NavMeshAgent agent { get; set; }
    Rigidbody rb;

    // Use this for initialization
    public override void Start () {
        base.Start();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        anim.SetBool("Chase", true);

    }
    public override void Outro()
    {
        anim.SetBool("Chase", false);
        base.Outro();
    }

    // Update is called once per frame
    public override void Update () {
        if(agent != null)
        {
            Enemy.RotateTowardVelocity();
            agent.SetDestination(Player.transform.position);
            agent.Resume();
        }
    }


    // Basic Enemy States
    public override void ToIdle(BaseEnemy myEnemy)
    {
        // Idle from idle?  get out of here
        base.ToIdle(myEnemy);
    }

    public override void ToRoam(BaseEnemy myEnemy)
    {
        // Conditions to prevent idle to roam
        base.ToRoam(myEnemy);
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
