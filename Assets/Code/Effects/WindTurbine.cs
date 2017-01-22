using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTurbine : MonoBehaviour {

	[SerializeField] GameObject turbine;
	[SerializeField] Light turbineLight;
	[SerializeField] GameObject wall;
	[SerializeField] Light wallLight;
	[SerializeField] AnimationCurve wallLightIntensity;
	[SerializeField] AnimationCurve turbineLightIntensity;

	bool sequenceStarted = false;
	bool decorativeEnabled = false;
	IEnumerator decorativeCoroutine = null;

	// Use this for initialization
	void Start () {
		BellEventEmitterSingleton.Instance.Register(BellEventType.AirBellEvent, transform, Ping);
	}

	void Ping(BellEventType type, Transform transform, float delay) {
		if(!sequenceStarted) {
			sequenceStarted = true;
			StartCoroutine(TurbineSequence());
		} else if(decorativeEnabled) {
			if(decorativeCoroutine != null) {
				StopCoroutine(decorativeCoroutine);
			}
			decorativeCoroutine = DecorativeTurbineSequence();
			StartCoroutine(decorativeCoroutine);
		}
	}

	IEnumerator TurbineSequence() {
		float startTime = Time.realtimeSinceStartup;
		Vector3 targetPosition = wall.transform.position + Vector3.up * -7.5f;
		Vector3 startPosition = wall.transform.position;

		turbineLight.enabled = true;

		while(Time.realtimeSinceStartup - startTime < 5) {
			float delta = (Time.realtimeSinceStartup - startTime) / 5;
			turbineLight.intensity = turbineLightIntensity.Evaluate(delta);
			turbine.transform.Rotate(Vector3.up * 90 * Time.smoothDeltaTime);
			yield return null;
		}

		turbineLight.enabled = false;
		wallLight.enabled = true;
		startTime = Time.realtimeSinceStartup;

		while(Time.realtimeSinceStartup - startTime < 5) {
			float delta = (Time.realtimeSinceStartup - startTime) / 5;
			wallLight.intensity = wallLightIntensity.Evaluate(delta);
			wall.transform.position = Vector3.Lerp(startPosition, targetPosition, delta);
			yield return null;
		}
		wallLight.enabled = false;
		Destroy(wallLight);
		Destroy(wall);
		decorativeEnabled = true;
	}
	IEnumerator DecorativeTurbineSequence() {
		float startTime = Time.realtimeSinceStartup;
		turbineLight.enabled = true;

		while(Time.realtimeSinceStartup - startTime < 5) {
			float delta = (Time.realtimeSinceStartup - startTime) / 5;
			turbineLight.intensity = turbineLightIntensity.Evaluate(delta);
			turbine.transform.Rotate(Vector3.up * 90 * Time.smoothDeltaTime);
			yield return null;
		}

		turbineLight.enabled = false;
	}
}
