using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyState{
    public float AttackLength = 1.5f;
    float TimeInAttack = 0.0f;
	// Use this for initialization
	public override void Start () {
        // Do Damage
        // go To idle\
        Debug.Log("Enemy Attack!");
        if (Enemy != null)
        {
            TimeInAttack = 0.0f;
        }
    }

    // Update is called once per frame
    public override void Update () {
        TimeInAttack += Time.deltaTime;
		if(TimeInAttack > AttackLength)
        {
            ToIdle(Enemy);
        }
	}

    // Basic Enemy States
    public override void ToIdle(BaseEnemy myEnemy)
    {
        base.ToIdle(myEnemy);
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
        // Don't transition to attack from attack
    }

    // Responses to Bells
    // Super attack
    public override void ToFrenzy(BaseEnemy myEnemy)
    {
        //define frenzy behaviour
    }

    // stop attack; wander around
    public override void ToConfuse(BaseEnemy myEnemy)
    {
        ToRoam(myEnemy);
    }

    // go nice NPC
    public override void ToSubdue(BaseEnemy myEnemy)
    {
        ToIdle(myEnemy);
    }
}
