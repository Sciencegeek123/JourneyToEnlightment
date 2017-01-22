using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CricketAudioScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] CricketNoises;
    Player player;
    public float croakChance = 0.998f;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource != null)
        {
            if (audioSource.isPlaying == false
                && Random.Range(0.0f, 1.0f) > croakChance
                && CricketNoises.Length > 0)
            {
                audioSource.clip = CricketNoises[Random.Range(0, CricketNoises.Length - 1)];
                //Debug.Log("Croak!");
                audioSource.Play();
            }
        }
    }
}
