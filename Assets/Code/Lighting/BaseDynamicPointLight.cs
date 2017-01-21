using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDynamicPointLight : MonoBehaviour {

	[SerializeField] float LoopDuration = 5;
	[SerializeField] AnimationCurve IntensityOverDuration;
	[SerializeField] AnimationCurve RangeOverDuration;
	[SerializeField] Gradient ColorOverDuration;
	[SerializeField] Light AssociatedLight;
	
	// Update is called once per frame
	void Update () {
		float delta = (Time.realtimeSinceStartup % LoopDuration) / LoopDuration;
		AssociatedLight.intensity = IntensityOverDuration.Evaluate(delta);
		AssociatedLight.range = RangeOverDuration.Evaluate(delta);
		AssociatedLight.color = ColorOverDuration.Evaluate(delta);
	}
}
