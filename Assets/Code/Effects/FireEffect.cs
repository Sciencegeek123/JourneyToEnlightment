using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour {

	[SerializeField] ParticleSystem ps;

	// Use this for initialization
	void Start () {
        BellEventEmitterSingleton.Instance.Register(BellEventType.FireBellEvent, this.transform, Ping);
	}

    void Ping(BellEventType type, Transform transform, float delay)
    {
		ps.Play();
		Destroy(gameObject, 2.5f);
    }
}
