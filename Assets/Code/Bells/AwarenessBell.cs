using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwarenessBell : BaseBell
{
	[SerializeField] GameObject AwarenessParticlePrefab;
	[SerializeField] float delay = 5;

	float lastFire = -10;
    public override void Emit(float range)
    {
        Debug.Log("Emitting Awareness");
        //BellEventEmitterSingleton.Instance.Emit(BellEventType.AwarenessBellEvent, this.transform, range);
		Instantiate(AwarenessParticlePrefab,this.transform.position, this.transform.rotation,null);
    }
}
