using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSingleton : MonoBehaviour {

    private static StateSingleton instance;
    private static DBSingleton db;
    public int uid { get; set; }
    public int[] bells = new int[6];

    public static StateSingleton get()
    {
        if (instance == null)
        {
            instance = new StateSingleton();
        }
        return instance;
    }

	// Use this for initialization
	void Start () {
        db = DBSingleton.get();
        Debug.Log(db.createNewPlayer("User 1"));
        uid = 1;
        db.setBells();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setBells(int[] bellsArr)
    {
        for (int i = 0; i < bellsArr.Length; i++)
        {
            bellsArr[i] = bellsArr[i];
        }
    }
}
