using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectRaycast : MonoBehaviour
{
    public int rayLength = 5;
    public LayerMask layerMaskInteract; // This should include both "Inspectable" objects and walls/obstacles
    private ObjectController raycastedObj;

    public Image crosshair;
    private bool isCrosshairActive;
    private bool doOnce;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            // First, check if the hit object is not a wall or another obstacle
            if (hit.collider.CompareTag("Inspectable"))
            {
                ObjectController currentObj = hit.collider.gameObject.GetComponent<ObjectController>();

                // Check if the raycasted object is different from the previous one
                if (currentObj != raycastedObj)
                {
                    // If there was a previous object, hide its name
                    if (raycastedObj != null)
                    {
                        raycastedObj.HideObjectName();
                    }

                    // Update to the new object and reset doOnce
                    raycastedObj = currentObj;
                    doOnce = false;
                }

                if (!doOnce)
                {
                    raycastedObj.ShowObjectName();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    raycastedObj.ShowObjectDialogue();
                }
            }
            else
            {
                // If it's not an inspectable object (e.g., a wall), reset the interaction
                ResetInteraction();
            }
        }
        else
        {
            // If the raycast hits nothing, reset the interaction
            ResetInteraction();
        }
    }

    private void ResetInteraction()
    {
        if (isCrosshairActive && raycastedObj != null)
        {
            raycastedObj.HideObjectName();
            CrosshairChange(false);
            doOnce = false;
            raycastedObj = null;
        }
    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
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
