using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterractRaycast : MonoBehaviour
{

    public int rayLength = 5;
    public LayerMask layerMaskInteract;

    public Image crosshair;
    private bool isCrosshairActive;


    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("Inspectable"))
            {
                DoorMechanic doorMechanic = hit.collider.gameObject.GetComponent<DoorMechanic>();
                DoorCameraMechanic doorCameraMechanic = hit.collider.gameObject.GetComponent<DoorCameraMechanic>();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (doorMechanic != null)
                    {
                        doorMechanic.Interract();
                    }
                    else if (doorCameraMechanic != null)
                    {
                        doorCameraMechanic.Interact();
                    }
                }
                isCrosshairActive = true;
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
            }
        }
    }

    void CrosshairChange(bool on)
    {
        if (on)
        {
            crosshair.color = Color.blue;
        }
        else
        {
            crosshair.color = Color.red;
            isCrosshairActive = false;
        }
    }
}
