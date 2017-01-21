﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    private static StateSingleton ss;
    private static DBSingleton db;
    public float charge = 0f;
    public float cooldown = 0f;

    void Awake()
    {
        ss = StateSingleton.get();
        db = DBSingleton.get();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("PrevBell"))
        {
            Debug.Log("Grabbing Previous Bell");
            if (ss.curBell == 0)
            {
                if (ss.bells[5].isActive)
                {
                    ss.curBell = 5;
                }
            }
            else
            {
                ss.curBell--;
            }
        }
        if (Input.GetButtonDown("NextBell"))
        {
            Debug.Log("Grabbing Next Bell");
            if (ss.curBell == 5)
            {
                ss.curBell = 0;
            }
            else
            {
                if (ss.bells[ss.curBell + 1].isActive)
                {
                    ss.curBell++;
                }
            }
        }

        if (Input.GetButton("Fire1"))
        {
            if (cooldown == 0f)
            {
                charge += Time.deltaTime;
                if (charge == 5f)
                {
                    charge = 5f;
                }
            }
        }else
        {
            if(charge > 0)
            {
                cooldown = charge;
                charge = 0;
                ss.bells[ss.curBell].Emit();
            }else
            {
                cooldown -= Time.deltaTime;
            }
        }
    }
}