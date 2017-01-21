using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    private static StateSingleton ss;
    private static DBSingleton db;

	// Use this for initialization
	void Start () {
        ss = StateSingleton.get();
        db = DBSingleton.get();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
