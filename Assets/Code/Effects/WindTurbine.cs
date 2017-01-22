using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTurbine : MonoBehaviour {

	[SerializeField] GameObject turbine;
	[SerializeField] GameObject wall;

	bool sequenceStarted = false;

	// Use this for initialization
	void Start () {
		BellEventEmitterSingleton.Instance.Register(BellEventType.AirBellEvent, transform, Ping);
	}

	void Ping(BellEventType type, Transform transform, float delay) {
		if(!sequenceStarted) {
			sequenceStarted = true;
			StartCoroutine(TurbineSequence());
		}
	}

	IEnumerator TurbineSequence() {
		float startTime = Time.realtimeSinceStartup;
		Vector3 targetPosition = wall.transform.position + Vector3.up * -5;
		Vector3 startPosition = wall.transform.position;

		while(Time.realtimeSinceStartup - startTime < 5) {
			turbine.transform.Rotate(Vector3.up * 90 * Time.smoothDeltaTime);
			yield return null;
		}

		startTime = Time.realtimeSinceStartup;

		while(Time.realtimeSinceStartup - startTime < 5) {
			wall.transform.position = Vector3.Lerp(startPosition, targetPosition, (Time.realtimeSinceStartup - startTime) / 5);
			yield return null;
		}

	}
}
