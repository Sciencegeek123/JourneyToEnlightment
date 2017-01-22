using UnityEngine;
using System.Collections;

public class AwarenessParticles : MonoBehaviour {
    [SerializeField] Light mySpotLight;
    [SerializeField] Light myPointLight;
    [SerializeField] ParticleSystem myParticleSystem;
	[SerializeField] AnimationCurve SpotLightIntensityCurve;
	[SerializeField] AnimationCurve PointLightIntensityCurve;
	[SerializeField] AnimationCurve SpotLightAngleCurve;
	[SerializeField] AnimationCurve FogStartCurve;
	[SerializeField] AnimationCurve FogEndCurve;
	[SerializeField] float SpotLightDuration = 5;

    void Start() {
        StartCoroutine(PlayLightCoRoutine());
    }

	IEnumerator PlayLightCoRoutine() {
		float startTime = Time.realtimeSinceStartup;

		myParticleSystem.Play();
		
		while(Time.realtimeSinceStartup - startTime < SpotLightDuration) {
			float delta = (Time.realtimeSinceStartup - startTime) / SpotLightDuration;
			float spotAngle = Mathf.Clamp01(SpotLightAngleCurve.Evaluate(delta))*180;
			float spotIntensity = SpotLightIntensityCurve.Evaluate(delta);
			float pointIntensity = PointLightIntensityCurve.Evaluate(delta);
            RenderSettings.fogStartDistance = FogStartCurve.Evaluate(delta);
            RenderSettings.fogEndDistance = FogEndCurve.Evaluate(delta);

			mySpotLight.intensity = spotIntensity;
			mySpotLight.spotAngle = spotAngle;
			myPointLight.intensity = pointIntensity;

			yield return null;
		}

		myParticleSystem.Stop();
        Destroy(gameObject);
	}
}