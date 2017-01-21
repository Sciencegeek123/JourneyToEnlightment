using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSingleton {

    private static StateSingleton instance;
    private static DBSingleton db;
    public int uid = 0;
    public int[] bells = new int[6];
    public AwarenessBell awarenessBell = null;
    public AirBell airBell = null;
    public FireBell fireBell = null;
    public WaterBell waterBell = null;
    public EarthBell earthBell = null;
    public EnlightenmentBell enlightenmentBell = null;

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
                switch (i)
                {
                    case 0: awarenessBell = Player.FindObjectOfType<AwarenessBell>();
                        break;
                    case 1: airBell = Player.FindObjectOfType<AirBell>();
                        break;
                    case 2: fireBell = Player.FindObjectOfType<FireBell>();
                        break;
                    case 3: waterBell = Player.FindObjectOfType<WaterBell>();
                        break;
                    case 4: earthBell = Player.FindObjectOfType<EarthBell>();
                        break;
                    case 5: enlightenmentBell = Player.FindObjectOfType<EnlightenmentBell>();
                        break;
                    default:
                        break;
                }
                bells[i] = bellsArr[i];
            }
        }
    }
}
