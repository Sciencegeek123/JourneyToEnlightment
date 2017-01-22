﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Base Enemy State:  Define Functions in childdren and call base function to 
 *  implement basic functionality in child  
 */

public class EnemyState : MonoBehaviour {
    public BaseEnemy Enemy;
    public GameObject Player;

    [SerializeField]
    Animator anim;
	// Use this for initialization
	public virtual void Start () {
        if(anim==null) {
        anim = GetComponent<Animator>();
        }
	}
	
	// Update is called once per frame
	public virtual void Update () {
	}

    // Basic Enemy States
    // Transition exclusion rules in these
    public virtual void ToIdle(BaseEnemy myEnemy)
    {
        if (anim)
        {
            anim.SetBool("Roam", false);
            anim.SetBool("Chase", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Subdue", false);
            anim.SetBool("Confuse", false);
            anim.SetBool("Frenzy", false);
            anim.SetBool("Idle", true);
        }
        EnemyState tempState = null;
        tempState = GetComponent<EnemyIdle>();
        if (tempState != null)
        {
            myEnemy.SetState(tempState);
            myEnemy.agent.SetDestination(gameObject.transform.position);
        }
    }

    public virtual void ToRoam(BaseEnemy myEnemy)
    {
        if (anim)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Chase", false);
            anim.SetBool("Roam", true);
        }
        EnemyState tempState = null;
        tempState = GetComponent<EnemyRoam>();
        if (tempState != null)
        {
            myEnemy.SetState(tempState);
        }
    }

    public virtual void ToChase(BaseEnemy myEnemy)
    {
        if (anim)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Roam", false);
            anim.SetBool("Chase", true);
        }
        EnemyState tempState = null;
        tempState = GetComponent<EnemyChase>();

        if (tempState != null)
        {
            myEnemy.SetState(tempState);
        }
    }

    public virtual void ToAttack(BaseEnemy myEnemy)
    {
        if (anim)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Chase", false);
            anim.SetBool("Attack", true);
        }
        EnemyState tempState = null;
        tempState = GetComponent<EnemyAttack>();

        if (tempState != null)
        {
            myEnemy.SetState(tempState);
        }
    }

    // Responses to Bells
    // Super attack
    public virtual void ToFrenzy(BaseEnemy myEnemy)
    {
        if (anim)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Frenzy", true);
        }
        EnemyState tempState = null;
        tempState = GetComponent<EnemyFrenzy>();

        if (tempState != null)
        {
            myEnemy.SetState(tempState);
        }
    }

    // stop attack; wander around
    public virtual void ToConfuse(BaseEnemy myEnemy)
    {
        if (anim)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Confuse", true);
        }
        EnemyState tempState = null;
        tempState = GetComponent<EnemyConfuse>();

        if (tempState != null)
        {
            myEnemy.SetState(tempState);
        }
    }

    // go nice NPC
    public virtual void ToSubdue(BaseEnemy myEnemy)
    {
        if (anim)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Subdue", true);
        }
        EnemyState tempState = null;
        tempState = GetComponent<EnemySubdue>();

        if (tempState != null)
        {
            myEnemy.SetState(tempState);
        }
    }
}
