﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwarenessCrystalEffect : MonoBehaviour {
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
        BellEventEmitterSingleton.Instance.Register(BellEventType.AwarenessBellEvent, transform, null);
        InitialMaterial = this.gameObject.GetComponent<MeshRenderer>().material;
    }

    float startTime = -60;

    void Update() {
        if(startTime < Time.realtimeSinceStartup && Time.realtimeSinceStartup - startTime < duration) {
            float delta = (Time.realtimeSinceStartup - startTime) / duration;
            if(this.gameObject.GetComponent<MeshRenderer>().material != crystalSpecialMaterial) {
                this.gameObject.GetComponent<MeshRenderer>().material = crystalSpecialMaterial;
            }
            crystalLight.color = PointLightColor;
            crystalLight.intensity = PointLightIntensityOverLife.Evaluate(delta);
            crystalSpecialMaterial.SetColor("_EmissionColor", EmissionColorOverLife.Evaluate(delta));
        } else {
            if(this.gameObject.GetComponent<MeshRenderer>().material != InitialMaterial) {
                this.gameObject.GetComponent<MeshRenderer>().material = InitialMaterial;
            }
        }
    }

    void Ping(BellEventType type, Transform transform, float delay) {
        startTime = Time.realtimeSinceStartup + delay;
    }
}