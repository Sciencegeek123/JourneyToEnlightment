using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBell : BaseBell
{
    public override void Emit(float range)
    {
        Debug.Log("Emitting Air");
        BellEventEmitterSingleton.Instance.Emit(BellEventType.AirBellEvent, GetComponentInParent<Transform>(), range);
    }
}
