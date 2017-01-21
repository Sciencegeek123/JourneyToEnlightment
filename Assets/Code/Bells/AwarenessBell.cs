using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwarenessBell : BaseBell
{
    public override void Emit(float range)
    {
        Debug.Log("Emitting Awareness");
        BellEventEmitterSingleton.Instance.Emit(BellEventType.AwarenessBellEvent, GetComponentInParent<Transform>(), range);
    }
}
