using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDynamicPointLight : MonoBehaviour
{

    [SerializeField] float LoopDuration = 5;
    [SerializeField] AnimationCurve IntensityOverDuration;
    [SerializeField] AnimationCurve RangeOverDuration;
    [SerializeField] Gradient ColorOverDuration;
    [SerializeField] Light AssociatedLight;

    StateSingleton ss;

    void Start()
    {
        ss = StateSingleton.get();
    }

    // Update is called once per frame
    void Update()
    {
        if (ss.player == null || (ss.player.transform.position - transform.position).magnitude > 100)
        {
            if (AssociatedLight.enabled) { AssociatedLight.enabled = false; }
        }
        else
        {
            if (!AssociatedLight.enabled) { AssociatedLight.enabled = true; }
            float delta = (Time.realtimeSinceStartup % LoopDuration) / LoopDuration;
            AssociatedLight.intensity = IntensityOverDuration.Evaluate(delta);
            AssociatedLight.range = RangeOverDuration.Evaluate(delta);
            AssociatedLight.color = ColorOverDuration.Evaluate(delta);
        }
    }
}
