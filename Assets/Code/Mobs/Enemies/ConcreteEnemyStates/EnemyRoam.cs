using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRoam : EnemyState
{
    public Vector3 RoamToPosition;
    public float MinRoamDistance = 1.5f;
    public float MaxRoamDistance = 4.0f;

    void GetNewRoamPosition()
    {
        // Find a random spot in a circle from ya
        RoamToPosition = Random.insideUnitCircle * Random.Range(MinRoamDistance, MaxRoamDistance);
        RoamToPosition += gameObject.transform.position;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.SetDestination(RoamToPosition);
        }
        //Debug.Log("Target Location Vector: " + RoamToPosition.ToString());
    }
    // Use this for initialization
    public override void Start () {
        base.Start();
        GetNewRoamPosition();
    }

    // Update is called once per frame
    public override void Update () {
        if (Mathf.Abs((RoamToPosition - gameObject.transform.position).magnitude) < 0.1f)
        {
            GetNewRoamPosition();
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
