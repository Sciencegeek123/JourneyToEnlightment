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
            awarenessBell.Emit(25f);
            bellSource.clip = bellSounds[bellNum];
            bellSource.Play();
            Debug.Log("Bell Attained");
            ss.bells[bellNum] = true;
            Destroy(this.gameObject);
        }
    }
}
