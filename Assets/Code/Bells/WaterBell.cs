using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBell : BaseBell
{
    public override void Emit(float range)
    {
        Debug.Log("Emitting Water");
        //BellEventEmitterSingleton.Instance.Emit(BellEventType.WaterBellEvent, GetComponentInParent<Transform>(), range);
<<<<<<< HEAD
    
        //BellEventEmitterSingleton.Instance.Emit(BellEventType.AwarenessBellEvent, this.transform, range);
		Instantiate(WaterParticlePrefab,this.transform.position, this.transform.rotation,null);

        foreach (var item in BellEventEmitterSingleton.Instance.PingListeners[(int)BellEventType.AwarenessBellEvent])
        {
            if (item.p != null && item.o != null && (item.o.position - transform.position).magnitude < range)
            {
                item.p(BellEventType.AwarenessBellEvent, transform, Mathf.Sqrt((item.o.position - transform.position).magnitude) + 2.5f);
            }
        }
        foreach (var item in BellEventEmitterSingleton.Instance.PingListeners[(int)BellEventType.AllBellEvents])
        {
            if (item.p != null && item.o != null && (item.o.position - transform.position).magnitude < range)
            {
                item.p(BellEventType.AwarenessBellEvent, transform, Mathf.Sqrt((item.o.position - transform.position).magnitude) + 2.5f);
            }
        }
=======
>>>>>>> 9ffff481e8cab0c4c0e3d00a32fccbeb5ddaa76a
    }
}
