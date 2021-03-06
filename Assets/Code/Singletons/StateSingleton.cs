﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSingleton {

    private static StateSingleton instance;
    public int uid = 0;

    public Player player;
    public bool[] bells = new bool[6];

    public int curBell = 0;

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
            if (bellsArr[i] == 1)
            {
                bells[i] = true;
            }
        }
    }
}
