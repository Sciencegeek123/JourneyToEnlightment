using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlightenmentEffect : BaseEffect
{

    [SerializeField]
    public AudioSource clip;


    // Use this for initialization
    void Start()
    {
        BellEventEmitterSingleton.Instance.Register(BellEventType.EnlightenmentBellEvent, transform, null);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Complete()
    {
        Debug.Log("Enlightenment Puzzle Solved");
        //clip.Play();
    }

}
