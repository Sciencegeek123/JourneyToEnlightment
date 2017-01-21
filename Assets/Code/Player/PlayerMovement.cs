using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Camera cam;
    public float rotSpeed = 90;
    
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        /*if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
            
        }
        moveDirection.y -= gravity * Time.deltaTime;
        transform.Rotate(0, Input.GetAxis("Rotate") * rotSpeed * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);*/
    }
}
