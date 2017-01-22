using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Camera cam;
    public float rotSpeed = 90;
    NavMeshAgent agent;
    RaycastHit outHit;
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        if (Input.GetMouseButton(0)) {
            HandleAutoMove();
        }
    }

    public void HandleAutoMove()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out outHit))
        {
            //sDebug.Log(outHit.transform.gameObject.layer);
            if(outHit.transform.gameObject.layer == 9) {
                agent.SetDestination(outHit.point);
                agent.Resume();
            } else {
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
