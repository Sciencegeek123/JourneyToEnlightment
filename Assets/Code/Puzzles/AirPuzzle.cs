using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPuzzle : PuzzleBase{

    [SerializeField]
    public AudioSource clip;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Complete()
    {
        Debug.Log("Air Puzzle Solved");
        //clip.Play();
        StartCoroutine(Death());
    }

}
