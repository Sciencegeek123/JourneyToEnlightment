using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DripHandler : MonoBehaviour 
{
	ParticleSystem part;
	Light light;
	//BaseDynamicPointLight dpl;
	public float dripPulseDuration;
	[SerializeField] AnimationCurve IntensityOverDuration;
	[SerializeField] AnimationCurve RangeOverDuration;
	[SerializeField] Gradient ColorOverDuration;
	[SerializeField] ParticleSystem part2;
	[SerializeField] AudioClip a1, a2, a3, a4, a5, a6; //Every water drop clip

	// Use this for initialization
	void Start () 
	{
		part = GetComponent<ParticleSystem> ();
		//part2 = GetComponentInChildren<ParticleSystem> ();
		GameObject go = GameObject.FindGameObjectsWithTag ("dripLight") [0];
		light = go.GetComponent<Light> ();

		//light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnParticleCollision(GameObject go)
	{
		StartCoroutine("DripLightPulse");

	}

	IEnumerator DripLightPulse()
	{
		float startTime = Time.realtimeSinceStartup;

		light.enabled = true;
		//light.range = 10;
		//light.intensity = 4.9f;
		part2.Play();
		while (Time.realtimeSinceStartup - startTime < dripPulseDuration) 
		{
			/*float delta = (Time.realtimeSinceStartup % dripPulseDuration) / dripPulseDuration;
			light.intensity = IntensityOverDuration.Evaluate(delta);
			light.range = RangeOverDuration.Evaluate(delta);
			light.color = ColorOverDuration.Evaluate(delta);*/

			yield return null;
		}
		part2.Stop ();
		light.enabled = false;
	}
}
