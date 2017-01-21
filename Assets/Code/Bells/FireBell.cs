using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBell : BaseBell
{
    public override void Emit()
    {
        Debug.Log("Emitting Fire");
    }
}
