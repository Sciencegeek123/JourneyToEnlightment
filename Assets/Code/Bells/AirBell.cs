using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBell : BaseBell
{
    [SerializeField] GameObject WindProjectile;

    float startTime;
    int emittedParticles = 5;
    public override void Emit(float range)
    {
        Debug.Log("Emitting Air");
        //BellEventEmitterSingleton.Instance.Emit(BellEventType.AirBellEvent, GetComponentInParent<Transform>(), range);
        emittedParticles = 0;


        foreach (var item in BellEventEmitterSingleton.Instance.PingListeners[(int)BellEventType.AirBellEvent])
        {
            if (item.p != null)
            {
                if ((item.o.position - transform.position).magnitude < range)
                {
                    float distanceFromLine = Vector3.Cross(transform.rotation * Vector3.forward, item.o.position - transform.position).magnitude;
                    Debug.Log("Line distance: " + distanceFromLine);
                    if (distanceFromLine < 5)
                    {
                        item.p(BellEventType.AirBellEvent, transform, Mathf.Sqrt((item.o.position - transform.position).magnitude) + 2.5f);
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
                        item.p(BellEventType.AirBellEvent, transform, Mathf.Sqrt((item.o.position - transform.position).magnitude) + 2.5f);
                    }
                }
            }
        }
    }

    void Update()
    {
        if (emittedParticles < 5 && Time.realtimeSinceStartup - startTime > 0.25f)
        {
            startTime = Time.realtimeSinceStartup;
            emittedParticles++;

            Quaternion targetRotation = transform.rotation * Quaternion.AngleAxis(-10 + 5 * emittedParticles, Vector3.up);

            Instantiate(WindProjectile, transform.position, targetRotation);
        }
    }
}
