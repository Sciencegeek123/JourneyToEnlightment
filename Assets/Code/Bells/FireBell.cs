using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBell : BaseBell
{
    public override void Emit(float range)
    {
        Debug.Log("Emitting Fire");
        BellEventEmitterSingleton.Instance.Emit(BellEventType.FireBellEvent, GetComponentInParent<Transform>(), range);
    }
}
