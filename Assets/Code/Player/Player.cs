﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Player : MonoBehaviour
{


    private static StateSingleton ss;
    private Vector3 moveDirection = Vector3.zero;

    public float cooldown = 5f;
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


    public AudioClip walk;
    public AudioClip[] bellSounds;
    NavMeshAgent agent;
    RaycastHit outHit;
    CharacterController controller;
    Animator anim;

    public AudioSource walkSource;
    public AudioSource bellSource;


    void Awake()
    {
        ss = StateSingleton.get();
        ss.player = this;
        ss.uid = 1;
        agent = GetComponent<NavMeshAgent>();
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        walkSource.clip = walk;
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
            if (walkSource.isPlaying == false)
                walkSource.Play();
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", true);

            HandleAutoMove();
        }


        if (Input.GetButtonDown("PrevBell"))
        {
            if (ss.curBell == 0)
            {
                if (ss.bells[5])
                {
                    Debug.Log("Grabbing Previous Bell");
                    ss.curBell = 5;
                }
            }
            else
            {
                Debug.Log("Grabbing Previous Bell");
                ss.curBell--;
            }
        }
        if (Input.GetButtonDown("NextBell"))
        {
            if (ss.curBell == 5)
            {
                Debug.Log("Grabbing Next Bell");
                ss.curBell = 0;
            }
            else
            {
                if (ss.bells[ss.curBell + 1])
                {
                    Debug.Log("Grabbing Next Bell");
                    ss.curBell++;
                }
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (cooldown == 0)
            {
                cooldown = 5f;
                bellSource.clip = bellSounds[ss.curBell];
                bellSource.Play();
                if (ss.bells[ss.curBell])
                {
                    switch (ss.curBell)
                    {
                        case 0:
                            awarenessBell.Emit(25f);
                            break;
                        case 1:
                            airBell.Emit(25f);
                            break;
                        case 2:
                            fireBell.Emit(25f);
                            break;
                        case 3:
                            waterBell.Emit(25f);
                            break;
                        case 4:
                            earthBell.Emit(25f);
                            break;
                        case 5:
                            enlightenmentBell.Emit(25f);
                            break;
                        default:
                            break;

                    }
                }
            }
        }
        else
        {
            cooldown -= Time.deltaTime;
            if (cooldown < 0)
            {
                cooldown = 0;
            }
        }

        //handle exiting auto move from manual control
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        float rotation = Input.GetAxis("Rotate");
        if (moveDirection.magnitude > 0.1f || rotation != 0f)
        {
            if (walkSource.isPlaying == false)
                walkSource.Play();
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", true);
            CancelAutoMove();
            controller.Move(moveDirection * Time.deltaTime);
            transform.Rotate(0, rotation * rotSpeed * Time.deltaTime, 0);
        }
        else if (agent.velocity.magnitude < 0.1f)
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
