using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttainBell : MonoBehaviour {

    public int bellNum;
    [SerializeField]
    public AwarenessBell awarenessBell = null;
    [SerializeField]
    public AirBell airBell = null;
    [SerializeField]
    public FireBell fireBell = null;
    [SerializeField]
    public WaterBell waterBell = null;
    [SerializeField]
    public EarthBell earthBell = null;
    [SerializeField]
    public EnlightenmentBell enlightenmentBell = null;

    public AudioClip[] bellSounds;

    public AudioSource bellSource;

    private CapsuleCollider col;
    private static StateSingleton ss;

    [SerializeField] float duration = 5;
    [SerializeField] Light crystalLight;
    [SerializeField] Material crystalSpecialMaterial;
    [SerializeField] Color PointLightColor;
    [SerializeField] AnimationCurve PointLightIntensityOverLife;
    [SerializeField] Gradient EmissionColorOverLife;


    private Material InitialMaterial;

    float startTime = -60;

	// Use this for initialization
	void Start () {
        //col = GetComponent<CapsuleCollider>();
        ss = StateSingleton.get();
        BellEventEmitterSingleton.Instance.Register(BellEventType.AwarenessBellEvent, this.transform, Ping);
        InitialMaterial = this.gameObject.GetComponent<MeshRenderer>().material;
    }
	
	// Update is called once per frame
	void Update () {
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

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            switch (bellNum)
            {
                case 0:
                    awarenessBell.Emit(25f);
                    break;
                case 1:
                    airBell.Emit(25f);
                    break;
                case 2:
                    fireBell.Emit(25f);
                    break;
                case 3:
                    waterBell.Emit(25f);
                    break;
                case 4:
                    earthBell.Emit(25f);
                    break;
                case 5:
                    enlightenmentBell.Emit(25f);
                    break;
                default:
                    break;

            }
            bellSource.clip = bellSounds[bellNum];
            bellSource.Play();
            Debug.Log("Bell Attained");
            ss.bells[bellNum] = true;
            Destroy(this.gameObject);
        }
    }
    void Ping(BellEventType type, Transform transform, float delay)
    {
        if (Time.realtimeSinceStartup - startTime > duration)
        {
            startTime = Time.realtimeSinceStartup + delay;
        }
    }
}
