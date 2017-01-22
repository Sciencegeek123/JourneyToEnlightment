using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsCheats : MonoBehaviour {

    // Use this for initialization
    private static BellEventEmitterSingleton bees;
    void Start()
    {
        bees = BellEventEmitterSingleton.Instance;
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKeyDown("f1"))
        {
            Debug.Log("Emitting Awareness...");
            aw
            bees.Emit(BellEventType.AwarenessBellEvent, transform, 5f);
        }
        if (Input.GetKeyDown("f2"))
        {
            Debug.Log("Emitting Air...");
            bees.Emit(BellEventType.AirBellEvent, transform, 5f);
        }
        if (Input.GetKeyDown("f3"))
        {
            Debug.Log("Emitting Fire...");
            bees.Emit(BellEventType.FireBellEvent, transform, 5f);
        }
        if (Input.GetKeyDown("f4"))
        {
            Debug.Log("Emitting Water...");
            bees.Emit(BellEventType.WaterBellEvent, transform, 5f);
        }
        if (Input.GetKeyDown("f5"))
        {
            Debug.Log("Emitting Earth...");
            bees.Emit(BellEventType.EarthBellEvent, transform, 5f);
        }
        if (Input.GetKeyDown("f6"))
        {
            Debug.Log("Emitting Everything...");
            bees.Emit(BellEventType.AllBellEvents, transform, 5f);
        }
        */
    }
}
