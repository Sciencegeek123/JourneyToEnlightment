using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePuzzle : PuzzleBase {

    [SerializeField]
    public AudioSource clip;


	// Use this for initialization
	void Start () {
        BellEventEmitterSingleton.Instance.Register(BellEventType.FireBellEvent, transform, null) ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Complete()
    {
        Debug.Log("Fire Puzzle Solved");
        //clip.Play();
        StartCoroutine(Death());
    }
}
