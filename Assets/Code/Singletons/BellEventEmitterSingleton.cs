using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BellPing(BellEventType type, Transform transform, float delay);

public enum BellEventType : int
{
    AwarenessBellEvent = 0,
    AirBellEvent,
    FireBellEvent,
    WaterBellEvent,
    EarthBellEvent,
    EnlightenmentBellEvent,
    AllBellEvents
}
public class BellEventEmitterSingleton
{
    public struct PingPair
    {
        public Transform o;
        public BellPing p;
        public PingPair(Transform o, BellPing p)
        {
            this.o = o;
            this.p = p;
        }
    }
    public List<PingPair>[] PingListeners = {
        new List<PingPair>(),
        new List<PingPair>(),
        new List<PingPair>(),
        new List<PingPair>(),
        new List<PingPair>(),
        new List<PingPair>(),
    new List<PingPair>() };
    private static BellEventEmitterSingleton instance = null;
    public static BellEventEmitterSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BellEventEmitterSingleton();
            }
            return instance;
        }
    }


    public void Register(BellEventType t, Transform o, BellPing f)
    {
        PingListeners[(int)t].Add(new PingPair(o,f));
    }
}