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
    }

    void Update() {
        if(emittedParticles < 5 && Time.realtimeSinceStartup - startTime > 0.25f) {
            startTime = Time.realtimeSinceStartup;
            emittedParticles++;

            Quaternion targetRotation = transform.rotation * Quaternion.AngleAxis(-10+5*emittedParticles,Vector3.up);

            Instantiate(WindProjectile, transform.position, targetRotation);
        }
    }
}
