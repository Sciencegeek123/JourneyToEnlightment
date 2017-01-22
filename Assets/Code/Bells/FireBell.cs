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
    }
}
