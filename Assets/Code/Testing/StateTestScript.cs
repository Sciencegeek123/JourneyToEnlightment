﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTestScript : MonoBehaviour {

    private static StateSingleton ss;
    private static DBSingleton db;
    public float charge = 0f;
    public float cooldown = 0f;

    // Use this for initialization
    void Start () {
        ss = StateSingleton.get();
        db = DBSingleton.get();
        ss.uid = db.createNewPlayer("User");
        db.updateBell(DBSingleton.BellType.Awareness);
        db.updateBell(DBSingleton.BellType.Air);
        db.updateBell(DBSingleton.BellType.Fire);
        db.updateBell(DBSingleton.BellType.Water);
        db.updateBell(DBSingleton.BellType.Earth);
        db.updateBell(DBSingleton.BellType.Enlightenment);
        db.setBells();
        db.deletePlayer(ss.uid);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PrevBell"))
        {
            Debug.Log("Grabbing Previous Bell");
        }
        if (Input.GetButtonDown("NextBell"))
        {
            Debug.Log("Grabbing Next Bell");
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
        }
        else
        {
            if (charge > 0)
            {
                cooldown = charge;
                charge = 0;
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
    }
}