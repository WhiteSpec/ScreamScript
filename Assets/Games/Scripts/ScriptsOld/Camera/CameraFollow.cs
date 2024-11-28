using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Player's head or face transform
    public Vector3 offset = new Vector3(0, 1.5f, 0); // Offset from the player's head

    public float rotationSpeed = 2.0f;
    public float maxVerticalAngle = 80.0f;
    public float minVerticalAngle = -80.0f;

    private float rotationX = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor

        // Set the initial position and rotation based on the target and offset
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.rotation = target.rotation;
            transform.SetParent(target); // Parent the camera to the target
        }
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        // Toggle cursor visibility when Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = Cursor.lockState == CursorLockMode.None ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = Cursor.lockState == CursorLockMode.None;
        }

        // Calculate mouse rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the camera horizontally and vertically based on mouse input
        target.Rotate(Vector3.up, mouseX * rotationSpeed); // Rotate the player horizontally

        rotationX -= mouseY * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0); // Rotate the camera vertically
    }
}
