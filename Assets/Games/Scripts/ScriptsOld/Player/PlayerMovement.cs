using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 2.0f;
    public float jumpForce = 5.0f;
    public float jumpCooldown = 1.0f; // Time between jumps
    public float runSpeed = 1.5f;

    private Rigidbody rb;
    public bool canJump = true;
    private float originalSpeed;    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalSpeed = movementSpeed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed *= runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = originalSpeed;
        }

        // Calculate mouse rotation
        float mouseX = Input.GetAxis("Mouse X");

        // Rotate the character horizontally based on mouse input
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);


        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
            Invoke("EnableJump", jumpCooldown);
        }

    }

    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * -movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }

    }

    private void EnableJump()
    {
        canJump = true;
    }
}
