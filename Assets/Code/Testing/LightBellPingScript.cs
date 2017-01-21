using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBellPingScript : MonoBehaviour {


	[SerializeField] Light mySpotLight;
	[SerializeField] Light myPointLight;

	[SerializeField] ParticleSystem myParticleSystem;
	[SerializeField] float pingDuration = 15;

	[SerializeField] AnimationCurve SpotLightIntensityCurve;
	[SerializeField] AnimationCurve PointLightIntensityCurve;
	[SerializeField] AnimationCurve SpotLightAngleCurve;
	[SerializeField] Gradient PointLightColorCurve;
	[SerializeField] Gradient SpotLightColorCurve;

	IEnumerator pingCoroutineReference = null;

	// Use this for initialization
	void Start () {
		TestingSingleton.Instance.Register(this.transform, Ping);	
	}

	void Ping(float delay) {
		if(pingCoroutineReference != null) {
			StopCoroutine(pingCoroutineReference);
		}
		pingCoroutineReference = PingCoroutine(delay);
		StartCoroutine(pingCoroutineReference);
	}

	IEnumerator PingCoroutine(float delay = 0) {

		yield return new WaitForSeconds(delay);

		float startTime = Time.realtimeSinceStartup;

		//myParticleSystem.Play();
		
		while(Time.realtimeSinceStartup - startTime < pingDuration) {
			float delta = (Time.realtimeSinceStartup - startTime) / pingDuration;
			//float spotAngle = Mathf.Clamp01(SpotLightAngleCurve.Evaluate(delta))*180;
			float spotIntensity = SpotLightIntensityCurve.Evaluate(delta);
			//float pointIntensity = Mathf.Clamp01(SpotLightIntensityCurve.Evaluate(delta))*7+1;
			//Color spotColor = SpotLightColorCurve.Evaluate(delta);
			//Color pointColor = PointLightColorCurve.Evaluate(delta);

			mySpotLight.intensity = spotIntensity;

			Debug.Log(spotIntensity);
			//mySpotLight.spotAngle = spotAngle;
			//myPointLight.intensity = pointIntensity;

			yield return null;
		}

		//myParticleSystem.Stop();
	}
}
