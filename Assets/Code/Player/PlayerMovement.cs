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
        controller = GetComponent<CharacterController>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        if (moveDirection.magnitude > 0.1f)
        {
            CancelAutoMove();
            moveDirection.y -= gravity * Time.deltaTime;
            transform.Rotate(0, Input.GetAxis("Rotate") * rotSpeed * Time.deltaTime, 0);
            controller.Move(moveDirection * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0)) {
            HandleAutoMove();
        }
    }

    public void HandleAutoMove()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.origin);

        if (Physics.Raycast(ray, out outHit))
        {
            agent.SetDestination(outHit.transform.position);
            Debug.DrawRay(ray.origin, ray.origin);
        }
    }

    public void CancelAutoMove()
    {
        agent.SetDestination(transform.position);
    }
}
