using UnityEngine;

public class DoorCameraMechanic : MonoBehaviour
{
    public bool isActive = false;
    public bool activated = false;
    public Camera doorCamera; // Assign the door camera in the Inspector.
    private Camera mainCamera; // Reference to the main camera.

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Activate()
    {
        if (!isActive)
        {
            isActive = true;
            activated = true;

            if (mainCamera != null)
            {
                mainCamera.enabled = false;
            }
            if (doorCamera != null)
            {
                doorCamera.enabled = true;
                Debug.Log("Door camera activated.");
            }
        }
    }

    private void Deactivate()
    {
        if (isActive)
        {
            isActive = false;

            if (doorCamera != null)
            {
                doorCamera.enabled = false;
            }
            if (mainCamera != null)
            {
                mainCamera.enabled = true;
                Debug.Log("Main camera reactivated.");
            }
        }
    }

    public void Interact()
    {
        if (!isActive)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
    }
}
