using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanic : MonoBehaviour
{
    public bool isOpened = false;
    public bool opened = false;
    private Quaternion startRotation;
    private Quaternion endRotation;
    private float rotationSpeed = 5f; // Adjust the rotation speed as needed.

    private void Start()
    {
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(0, 90, 0) * startRotation;
    }

    public void OpenDoor()
    {
        if (!isOpened)
        {
            StartCoroutine(RotateDoor(endRotation));
            isOpened = true;
            opened = true;
        }
    }

    public void CloseDoor()
    {
        if (isOpened)
        {
            StartCoroutine(RotateDoor(startRotation));
            isOpened = false;
        }
    }

    private IEnumerator RotateDoor(Quaternion targetRotation)
    {
        float elapsedTime = 0f;
        Quaternion currentRotation = transform.rotation;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, elapsedTime);
            yield return null;
        }
    }

    public void Interract()
    {
        if (isOpened)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }
}
