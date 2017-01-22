using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Player : MonoBehaviour
{


    private static StateSingleton ss;
    private static DBSingleton db;
    private Vector3 moveDirection = Vector3.zero;


    public float charge = 0f;
    public float cooldown = 0f;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float rotSpeed = 90f;

    [SerializeField]
    public AwarenessBell awarenessBell = null;
    [SerializeField]
    public AirBell airBell = null;
    [SerializeField]
    public FireBell fireBell = null;
    [SerializeField]
    public WaterBell waterBell = null;
    [SerializeField]
    public EarthBell earthBell = null;
    [SerializeField]
    public EnlightenmentBell enlightenmentBell = null;


    NavMeshAgent agent;
    RaycastHit outHit;
    CharacterController controller;
    Animator anim;


    void Awake()
    {
        ss = StateSingleton.get();
        db = DBSingleton.get();
        ss.uid = 1;
        db.setBells();
        agent = GetComponent<NavMeshAgent>();
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", true);
            HandleAutoMove();
        }
        

        if (Input.GetButtonDown("PrevBell"))
        {
            Debug.Log("Grabbing Previous Bell");
            if (ss.curBell == 0)
            {
                if (ss.bells[5])
                    ss.curBell = 5;
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
                if (ss.bells[ss.curBell + 1])
                {
                    ss.curBell++;
                }
            }
        }

        if (Input.GetButton("Fire2"))
        {
            if (cooldown == 0f)
            {
                charge += Time.deltaTime;
                if (charge > 5f)
                {
                    charge = 5f;
                }
                if (Input.GetButton("Fire1"))
                {
                    if (charge > 0)
                    {
                        cooldown = charge;
                        charge = 0;
                    }
                }
            }else
            {
                cooldown -= Time.deltaTime;
                if (cooldown < 0f)
                {
                    cooldown = 0f;
                }
            }
        }
        else
        {
            if (charge > 0)
            {
                cooldown = charge;
                switch (ss.curBell)
                {
                    case 0:
                        if (ss.bells[0])
                            awarenessBell.Emit(charge);
                        break;
                    case 1:
                        if (ss.bells[1])
                            airBell.Emit(charge);
                        break;
                    case 2:
                        if (ss.bells[2])
                            fireBell.Emit(charge);
                        break;
                    case 3:
                        if (ss.bells[3])
                            waterBell.Emit(charge);
                        break;
                    case 4:
                        if (ss.bells[4])
                            earthBell.Emit(charge);
                        break;
                    case 5:
                        if (ss.bells[5])
                            enlightenmentBell.Emit(charge);
                        break;
                    default:
                        break;
                }
                charge = 0;
            }
            else
            {
                cooldown -= Time.deltaTime;
                if (cooldown < 0)
                    cooldown = 0;
            }
        }

        //handle exiting auto move from manual control
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        float rotation = Input.GetAxis("Rotate");
        if (moveDirection.magnitude > 0.1f || rotation!= 0f)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", true);
            CancelAutoMove();
            controller.Move(moveDirection * Time.deltaTime);
            transform.Rotate(0, rotation * rotSpeed * Time.deltaTime, 0);
        }else if (agent.velocity.magnitude < 0.1f)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);
        }
    }

    public void HandleAutoMove()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out outHit))
        {
            //sDebug.Log(outHit.transform.gameObject.layer);
            if (outHit.transform.gameObject.layer == 9)
            {
                agent.SetDestination(outHit.point);
                agent.Resume();
            }
            else
            {
                CancelAutoMove();
            }
            //Debug.DrawRay(ray.origin, ray.direction*10, Color.red, 10);
            //Debug.DrawRay(outHit.point, Vector3.up*10, Color.green, 10);
        }
    }

    public void CancelAutoMove()
    {
        agent.Stop();
    }
}
