using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Movement _movement;
    private Rotation _rotation;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float jumpCooldown = 1f;
    public float rotationSpeed = 2f;

    private Rigidbody rb;

    public bool canMove = true;
    public bool canJump = true;

    void Start()
    {
        _movement = new Movement();
        _rotation= GetComponent<Rotation>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        _rotation.CameraRotation(mouseX, rotationSpeed);
    }

    private void FixedUpdate()
    {
        if (canMove != false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                _movement.Forward(moveSpeed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                _movement.Backward(moveSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                _movement.Left(moveSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                _movement.Right(moveSpeed);
            }
        }
        if(canJump != false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _movement.Jump(rb, jumpForce);
                canJump = false;
                Invoke("EnableJump", jumpCooldown);
            }
        }
    }

    private void EnableJump()
    {
        canJump= true;
    }
}
