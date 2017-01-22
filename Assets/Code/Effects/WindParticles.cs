using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindParticles : MonoBehaviour {

	// Use this for initialization

	[SerializeField] float duration = 2.5f;
	[SerializeField] float speed = 2.5f;
	[SerializeField] AnimationCurve lightIntensityCurve;
	[SerializeField] Light light;
	float startTime;
	void Start () {
		startTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.realtimeSinceStartup - startTime > duration) {
			Destroy(this.gameObject);
			this.enabled = false;
		} else {
			this.transform.position += this.transform.rotation * Vector3.forward * speed * Time.smoothDeltaTime;
			float delta = (Time.realtimeSinceStartup - startTime) / duration;
			light.intensity = lightIntensityCurve.Evaluate(delta);
		}
	}
}
