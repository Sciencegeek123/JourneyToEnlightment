using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAudioScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] BatNoises;
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
                && BatNoises.Length > 0)
            {
                audioSource.clip = BatNoises[Random.Range(0, BatNoises.Length - 1)];
                //Debug.Log("Croak!");
                audioSource.Play();
            }
        }
    }
}
