using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlightenmentBell : BaseBell
{
    public override void Emit(float range)
    {
        Debug.Log("Emitting Enlightenment");
    }
}
