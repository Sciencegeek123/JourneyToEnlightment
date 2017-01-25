using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda : BaseEnemy
{

	// Use this for initialization
	public override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
	}

    public override void Ping(BellEventType type, Transform transform, float delay)
    {
        if (DebugEnemy)
        {
            Debug.Log("Received Ping");
        }

        if (type == BellEventType.AirBellEvent)
        {
            Frenzy();
            if (DebugEnemy)
            {
                Debug.Log(gameObject.name + " caught Air, frenzy");
            }
        }
        else if (type == BellEventType.FireBellEvent)
        {
            base.DoDeath();
            if (DebugEnemy)
            {
                Debug.Log(gameObject.name + " caught Fire, death");
            }
        }
        else if (type == BellEventType.WaterBellEvent)
        {
            Subdue();
            if (DebugEnemy)
            {
                Debug.Log(gameObject.name + " caught water, subduing");
            }
        }
    }

}
