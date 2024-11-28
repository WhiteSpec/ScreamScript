using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public void CameraRotation(float mouseX, float rotationSpeed)
    {
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);
    }
}
