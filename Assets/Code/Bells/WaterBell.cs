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
    }
}
