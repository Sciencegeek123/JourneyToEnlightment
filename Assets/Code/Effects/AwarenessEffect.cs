using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwarenessEffect : BaseEffect {

    [SerializeField]
    public AudioSource clip;


    // Use this for initialization
    void Start()
    {
        BellEventEmitterSingleton.Instance.Register(BellEventType.AwarenessBellEvent, transform, null);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Complete()
    {
        Debug.Log("Awareness Puzzle Solved");
        //clip.Play();
        StartCoroutine(Death());
    }

    public void found()
    {
    }

}
