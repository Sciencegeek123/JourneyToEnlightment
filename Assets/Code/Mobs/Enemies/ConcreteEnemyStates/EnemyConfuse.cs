using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConfuse : EnemyState {

    // Use this for initialization
    public override void Start () {
        base.Start();
        anim.SetBool("Confuse", true);
	}

    public override void Outro()
    {
        anim.SetBool("Confuse", false);
        base.Outro();
    }

    // Update is called once per frame
    public override void Update () {
	}

    // Basic Enemy States
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
        base.ToFrenzy(myEnemy);
    }

    // stop attack; wander around
    public override void ToConfuse(BaseEnemy myEnemy)
    {

    }

    // go nice NPC
    public override void ToSubdue(BaseEnemy myEnemy)
    {
        base.ToSubdue(myEnemy);
    }
}
