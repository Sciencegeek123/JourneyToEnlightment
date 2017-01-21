using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingSingleton {
    private static TestingSingleton instance = null;
    public static TestingSingleton Instance {
        get {
            if(instance == null) {
                instance = new TestingSingleton();
            }
            return instance;
        }
    }

    private struct PingPair {
        public Transform o;
        public BellPing p;
        public PingPair(Transform o, BellPing p) {
            this.o = o;
            this.p = p;
        }
    }

    private List<PingPair> pings = new List<PingPair>();

    public void Register(Transform o, BellPing f) {
        pings.Add(new PingPair(o,f));
    }

    public void Emit(Transform root, float range) {
        foreach (var item in pings)
        {
            if((item.o.position - root.position).magnitude < range) {
                item.p(5);
            }
        }
    }
}