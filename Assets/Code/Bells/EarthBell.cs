using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBell : BaseBell
{
    public override void Emit()
    {
        Debug.Log("Emitting Earth");
    }
}
