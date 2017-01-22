using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheats : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    public  AirPuzzle air;
    [SerializeField]
    private FirePuzzle fire;
    [SerializeField]
    private EarthPuzzle earth;

    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("f1"))
        {
            air.Complete();
        }
        if (Input.GetKeyDown("f2"))
        {
            fire.Complete();
        }
        if (Input.GetKeyDown("f3"))
        {
            earth.Complete();
        }
    }
}
