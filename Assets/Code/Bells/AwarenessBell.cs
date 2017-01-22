using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwarenessBell : BaseBell
{
	[SerializeField] Light mySpotLight;
	[SerializeField] Light myPointLight;

	[SerializeField] ParticleSystem myParticleSystem;

	[SerializeField] AnimationCurve SpotLightIntensityCurve;
	[SerializeField] AnimationCurve PointLightIntensityCurve;
	[SerializeField] AnimationCurve SpotLightAngleCurve;
	[SerializeField] AnimationCurve FogDensityCurve;
	[SerializeField] float SpotLightDuration = 5;
	private IEnumerator myLightCoRoutine = null;
    public override void Emit(float range)
    {
        Debug.Log("Emitting Awareness");
        BellEventEmitterSingleton.Instance.Emit(BellEventType.AwarenessBellEvent, GetComponentInParent<Transform>(), range);
			myLightCoRoutine = PlayLightCoRoutine();
			StartCoroutine(myLightCoRoutine);
			TestingSingleton.Instance.Emit(this.transform, 1000);
    }

	IEnumerator PlayLightCoRoutine() {
		float startTime = Time.realtimeSinceStartup;

		myParticleSystem.Play();
		
		while(Time.realtimeSinceStartup - startTime < SpotLightDuration) {
			float delta = (Time.realtimeSinceStartup - startTime) / SpotLightDuration;
			float spotAngle = Mathf.Clamp01(SpotLightAngleCurve.Evaluate(delta))*180;
			float spotIntensity = SpotLightIntensityCurve.Evaluate(delta);
			float pointIntensity = PointLightIntensityCurve.Evaluate(delta);
            RenderSettings.fogDensity = FogDensityCurve.Evaluate(delta);

			mySpotLight.intensity = spotIntensity;
			mySpotLight.spotAngle = spotAngle;
			myPointLight.intensity = pointIntensity;

			yield return null;
		}

		myParticleSystem.Stop();
	}
}
