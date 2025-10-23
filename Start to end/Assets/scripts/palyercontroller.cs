using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palyercontroller : MonoBehaviour
{
    public float speed = 10f;
    public CharacterController controller;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundcheck;
    public float groundDistance;
    public LayerMask groundmask;
    bool isGrounded;
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundmask);

        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(-2f * gravity * 3f);
        }

    }
}

