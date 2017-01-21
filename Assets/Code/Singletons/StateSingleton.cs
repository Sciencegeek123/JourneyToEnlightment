using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSingleton{

    private static StateSingleton instance;
    private static DBSingleton db;
    public int uid = 0;
    public int[] bells = new int[6];

    public static StateSingleton get()
    {
        if (instance == null)
        {
            instance = new StateSingleton();
        }
        Debug.Log("Connected to StateSingleton...");
        return instance;
    }

    public void setBells(int[] bellsArr)
    {
        for (int i = 0; i < bellsArr.Length; i++)
        {
            bells[i] = bellsArr[i];
        }
    }
}
