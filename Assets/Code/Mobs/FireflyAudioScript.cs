using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyAudioScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] fireflyNoises;
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
                && fireflyNoises.Length > 0)
            {
                audioSource.clip = fireflyNoises[Random.Range(0, fireflyNoises.Length - 1)];
                //Debug.Log("Croak!");
                audioSource.Play();
            }
        }
    }
}
