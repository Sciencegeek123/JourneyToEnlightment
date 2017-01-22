using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBell : BaseBell
{
    [SerializeField] ParticleSystem[] systems;
    public override void Emit(float range)
    {
        Debug.Log("Emitting Fire");
        //BellEventEmitterSingleton.Instance.Emit(BellEventType.FireBellEvent, GetComponentInParent<Transform>(), range);
        
        foreach (var item in systems)
        {
            item.Play();
        }
        
        foreach (var item in BellEventEmitterSingleton.Instance.PingListeners[(int)BellEventType.FireBellEvent])
        {
            if (item.p != null)
            {
                if ((item.o.position - transform.position).magnitude < range)
                {
                    float distanceFromLine = Vector3.Cross(transform.rotation * Vector3.forward, item.o.position - transform.position).magnitude;
                    Debug.Log("Line distance: " + distanceFromLine);
                    if (distanceFromLine < 5)
                    {
                        item.p(BellEventType.FireBellEvent, transform, Mathf.Sqrt((item.o.position - transform.position).magnitude) + 2.5f);
                    }
                }
            }
        }
        foreach (var item in BellEventEmitterSingleton.Instance.PingListeners[(int)BellEventType.AllBellEvents])
        {
            if (item.p != null)
            {
                if ((item.o.position - transform.position).magnitude < range)
                {
                    if (Vector3.Cross(transform.rotation * Vector3.forward, item.o.position - transform.position).magnitude < 5)
                    {
                        item.p(BellEventType.FireBellEvent, transform, Mathf.Sqrt((item.o.position - transform.position).magnitude) + 2.5f);
                    }
                }
            }
        }
    }
}
