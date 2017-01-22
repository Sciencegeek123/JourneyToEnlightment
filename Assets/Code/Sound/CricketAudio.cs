using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CricketAudio : MonoBehaviour {
	private AudioSource audioSrc;
	[SerializeField] AudioClip audio;
	ParticleSystem part;

	// Use this for initialization
	void Start () {
		audioSrc = GetComponent<AudioSource> ();
		//audio = audioSrc.
		//Debug.Log (audio);
		part = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (part.time <= .1f) 
		{
			//audioSrc.PlayOneShot (audio);
			audioSrc.Play();
		}*/
		audioSrc.Play ();
	}
}
