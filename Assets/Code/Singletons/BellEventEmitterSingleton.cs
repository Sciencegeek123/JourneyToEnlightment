using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void BellPing(BellEventType type, Transform transform, float delay);

public enum BellEventType
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
    private struct PingPair
    {
        public Transform o;
        public BellPing p;
        public PingPair(Transform o, BellPing p)
        {
            this.o = o;
            this.p = p;
        }
    }
    private Dictionary<BellEventType, List<PingPair>> PingDictionaries = new Dictionary<BellEventType, List<PingPair>>();
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

    BellEventEmitterSingleton()
    {
        PingDictionaries.Add(BellEventType.AwarenessBellEvent, new List<PingPair>());
        PingDictionaries.Add(BellEventType.AirBellEvent, new List<PingPair>());
        PingDictionaries.Add(BellEventType.FireBellEvent, new List<PingPair>());
        PingDictionaries.Add(BellEventType.WaterBellEvent, new List<PingPair>());
        PingDictionaries.Add(BellEventType.EarthBellEvent, new List<PingPair>());
        PingDictionaries.Add(BellEventType.EnlightenmentBellEvent, new List<PingPair>());
        PingDictionaries.Add(BellEventType.AllBellEvents, new List<PingPair>());
    }


    public void Register(BellEventType t, Transform o, BellPing f)
    {
        List<PingPair> dict;
        if (PingDictionaries.TryGetValue(t, out dict))
        {
            dict.Add(new PingPair(o, f));
        }
    }

    public void Emit(BellEventType type, Transform root, float range)
    {
        List<PingPair> dict;
        if (PingDictionaries.TryGetValue(type, out dict))
        {
            foreach (var item in dict)
            {
                if (item.p != null && (item.o.position - root.position).magnitude < range)
                {
                    item.p(type, root, Mathf.Sqrt((item.o.position - root.position).magnitude) + 2.5f);
                }
            }
            
        }
        if (PingDictionaries.TryGetValue(BellEventType.AllBellEvents, out dict))
        {
            foreach (var item in dict)
            {
                if (item.p != null && (item.o.position - root.position).magnitude < range)
                {
                    item.p(type, root, Mathf.Sqrt((item.o.position - root.position).magnitude) + 2.5f);
                }
            }
        }
    }
}