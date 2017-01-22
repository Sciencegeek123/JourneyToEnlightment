using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBell : BaseBell
{
	[SerializeField] GameObject WaterParticlePrefab;
    public override void Emit(float range)
    {
        Debug.Log("Emitting Water");
        //BellEventEmitterSingleton.Instance.Emit(BellEventType.WaterBellEvent, GetComponentInParent<Transform>(), range);
    
		Instantiate(WaterParticlePrefab,this.transform.position, this.transform.rotation,null);

        foreach (var item in BellEventEmitterSingleton.Instance.PingListeners[(int)BellEventType.AwarenessBellEvent])
        {
            if (item.p != null && (item.o.position - transform.position).magnitude < range)
            {
                item.p(BellEventType.AwarenessBellEvent, transform, Mathf.Sqrt((item.o.position - transform.position).magnitude) + 2.5f);
            }
        }
        foreach (var item in BellEventEmitterSingleton.Instance.PingListeners[(int)BellEventType.AllBellEvents])
        {
            if (item.p != null && (item.o.position - transform.position).magnitude < range)
            {
                item.p(BellEventType.AwarenessBellEvent, transform, Mathf.Sqrt((item.o.position - transform.position).magnitude) + 2.5f);
            }
        }
    }
    
}
