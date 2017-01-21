using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwarenessBell : BaseBell
{
    public override void Emit()
    {
        Debug.Log("Emitting Awareness");
    }
}
