using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwarenessCrystalEffect : MonoBehaviour
{
    [SerializeField] float duration = 5;
    [SerializeField] Light crystalLight;
    [SerializeField] Material crystalSpecialMaterial;
    [SerializeField] Color PointLightColor;
    [SerializeField] AnimationCurve PointLightIntensityOverLife;
    [SerializeField] Gradient EmissionColorOverLife;


    private Material InitialMaterial;

    // Use this for initialization
    void Start()
    {
        BellEventEmitterSingleton.Instance.Register(BellEventType.AwarenessBellEvent, this.transform, Ping);
        InitialMaterial = this.gameObject.GetComponent<MeshRenderer>().material;
    }

    float startTime = -60;

    void Update()
    {
        if (startTime < Time.realtimeSinceStartup && Time.realtimeSinceStartup - startTime < duration)
        {
            if (!crystalLight.enabled) { crystalLight.enabled = true; }
            float delta = (Time.realtimeSinceStartup - startTime) / duration;
            this.gameObject.GetComponent<MeshRenderer>().material = crystalSpecialMaterial;
            crystalLight.color = PointLightColor;
            crystalLight.intensity = PointLightIntensityOverLife.Evaluate(delta);
            this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", EmissionColorOverLife.Evaluate(delta));
        }
        else if (crystalLight.enabled) { crystalLight.enabled = false; }
    }

    void Ping(BellEventType type, Transform transform, float delay)
    {
        if (Time.realtimeSinceStartup - startTime > duration)
        {
            startTime = Time.realtimeSinceStartup + delay;
        }
    }
}
