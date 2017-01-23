using System.Collections;
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
    protected Animator anim;
    void Awake()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }
    // 
    //Use this for initialization
	public virtual void Start () {

	}
    // override in children to give outro functionality
    public virtual void Outro()
    {

    }
    // Update is called once per frame
    public virtual void Update () {
	}


    // Basic Enemy States
    // Transition exclusion rules in these
    public virtual void ToIdle(BaseEnemy myEnemy)
    {
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
        EnemyState tempState = null;
        tempState = GetComponent<EnemyRoam>();
        if (tempState != null)
        {
            myEnemy.SetState(tempState);
        }
    }

    public virtual void ToChase(BaseEnemy myEnemy)
    {
        EnemyState tempState = null;
        tempState = GetComponent<EnemyChase>();

        if (tempState != null)
        {
            myEnemy.SetState(tempState);
        }
    }

    public virtual void ToAttack(BaseEnemy myEnemy)
    {

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
        EnemyState tempState = null;
        tempState = GetComponent<EnemySubdue>();

        if (tempState != null)
        {
            myEnemy.SetState(tempState);
        }
    }
}
