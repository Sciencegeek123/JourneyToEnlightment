using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBellTestingScript : MonoBehaviour {

	[SerializeField] Light mySpotLight;
	[SerializeField] Light myPointLight;

	[SerializeField] ParticleSystem myParticleSystem;

	[SerializeField] AnimationCurve SpotLightIntensityCurve;
	[SerializeField] AnimationCurve PointLightIntensityCurve;
	[SerializeField] AnimationCurve SpotLightAngleCurve;
	[SerializeField] float SpotLightDuration = 5;
	private IEnumerator myLightCoRoutine = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)) {
			if(myLightCoRoutine != null) {
				StopCoroutine(myLightCoRoutine);
			}
			myLightCoRoutine = PlayLightCoRoutine();
			StartCoroutine(myLightCoRoutine);
		}
		
	}

	IEnumerator PlayLightCoRoutine() {
		float startTime = Time.realtimeSinceStartup;

		myParticleSystem.Play();
		
		while(Time.realtimeSinceStartup - startTime < SpotLightDuration) {
			float delta = (Time.realtimeSinceStartup - startTime) / SpotLightDuration;
			float spotAngle = Mathf.Clamp01(SpotLightAngleCurve.Evaluate(delta))*180;
			float spotIntensity = Mathf.Clamp01(SpotLightIntensityCurve.Evaluate(delta));
			float pointIntensity = Mathf.Clamp01(SpotLightIntensityCurve.Evaluate(delta))*7+1;

			mySpotLight.intensity = spotIntensity;
			mySpotLight.spotAngle = spotAngle;
			myPointLight.intensity = pointIntensity;

			yield return null;
		}

		myParticleSystem.Stop();
	}
}
