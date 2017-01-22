using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyAudioScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] fireflyNoises;
    Player player;
    public float croakChance = 0.998f;
    public float PitchRange = 1.5f;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = FindObjectOfType<Player>();
        audioSource.pitch += Random.Range(-PitchRange / 2, PitchRange / 2);
        audioSource.clip = fireflyNoises[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
