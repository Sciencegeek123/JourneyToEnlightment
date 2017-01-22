using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheats : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("f1"))
        {
            Debug.Log("Air Puzzle Solved");
        }
        if (Input.GetKeyDown("f2"))
        {
            Debug.Log("Fire Puzzle Solved");
        }
        if (Input.GetKeyDown("f3"))
        {
            Debug.Log("Earth Puzzle Solved");
        }
    }
}
