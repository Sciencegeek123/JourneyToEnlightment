using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBell : BaseBell
{
    public override void Emit()
    {
        Debug.Log("Emitting Air");
    }
}
