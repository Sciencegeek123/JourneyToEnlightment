using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlightenmentBell : BaseBell
{
    public override void Emit(float range)
    {
        Debug.Log("Emitting Enlightenment");
        foreach (var item in BellEventEmitterSingleton.Instance.PingListeners[(int)BellEventType.EnlightenmentBellEvent])
        {
            if (item.p != null && (item.o.position - transform.position).magnitude < range)
            {
                item.p(BellEventType.EnlightenmentBellEvent, transform, Mathf.Sqrt((item.o.position - transform.position).magnitude) + 2.5f);
            }
        }
        foreach (var item in BellEventEmitterSingleton.Instance.PingListeners[(int)BellEventType.AllBellEvents])
        {
            if (item.p != null && (item.o.position - transform.position).magnitude < range)
            {
                item.p(BellEventType.EnlightenmentBellEvent, transform, Mathf.Sqrt((item.o.position - transform.position).magnitude) + 2.5f);
            }
        }
    }
}
