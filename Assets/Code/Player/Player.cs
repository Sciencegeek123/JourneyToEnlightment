using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    private static StateSingleton ss;
    private static DBSingleton db;
    public float charge = 0f;
    public float cooldown = 0f;
    [SerializeField]
    AwarenessBell awarenessBell = null;
    [SerializeField]
    AirBell airBell = null;
    [SerializeField]
    FireBell fireBell = null;
    [SerializeField]
    WaterBell waterBell = null;
    [SerializeField]
    EarthBell earthBell = null;
    [SerializeField]
    EnlightenmentBell enlightenmentBell = null;


    void Awake()
    {
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
                if (ss.bells[5])
                    ss.curBell = 5;
            }else
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
            }else
            {
                if (ss.bells[ss.curBell + 1])
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
                switch (ss.curBell)
                {
                    case 0:
                        if (ss.bells[0])
                            awarenessBell.Emit();
                        break;
                    case 1:
                        if (ss.bells[1])
                            airBell.Emit();
                        break;
                    case 2:
                        if (ss.bells[2])
                            fireBell.Emit();
                        break;
                    case 3:
                        if (ss.bells[3])
                            waterBell.Emit();
                        break;
                    case 4:
                        if (ss.bells[4])
                            earthBell.Emit();
                        break;
                    case 5:
                        if (ss.bells[5])
                            enlightenmentBell.Emit();
                        break;
                    default:
                        break;
                }
            }else
            {
                cooldown -= Time.deltaTime;
                if (cooldown < 0)
                    cooldown = 0;
            }
        }
    }
}
