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

	// Use this for initialization
	void Start () {
        //col = GetComponent<CapsuleCollider>();
        ss = StateSingleton.get();
	}
	
	// Update is called once per frame
	void Update () {

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
}
