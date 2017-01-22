using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAudioScript : MonoBehaviour {
    AudioSource audioSource;
    public AudioClip[] FrogCroaks;
    Player player;
    public float croakChance = 0.98f;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        player = FindObjectOfType<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        if (audioSource != null)
        {
            if (audioSource.isPlaying == false
                && Random.Range(0.0f, 1.0f) > croakChance
                && FrogCroaks.Length > 0)
            {
                audioSource.clip = FrogCroaks[Random.Range(0, FrogCroaks.Length - 1)];
                //Debug.Log("Croak!");
                audioSource.Play();
            }
        }
    }
}
