using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBell : BaseBell
{
    public override void Emit(float range)
    {
        Debug.Log("Emitting Earth");
        BellEventEmitterSingleton.Instance.Emit(BellEventType.EarthBellEvent, GetComponentInParent<Transform>(), range);
    }
}
