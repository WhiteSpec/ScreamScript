using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastActions : MonoBehaviour
{
    public int rayLength = 5;
    public LayerMask layerMaskInteract;

    public List<State> states;         // List of states
    public Image crosshair;            // Crosshair UI element

    private bool isCrosshairActive;
    private bool doOnce;
    private GameObject lastHitObject;
    private int currentStateIndex = 0;

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract))
        {
            var currentState = states[currentStateIndex];
            foreach (var target in currentState.actionTargets)
            {
                if (hit.collider.gameObject == target.targetObject)
                {
                    if (hit.collider.gameObject != lastHitObject)
                    {
                        if (lastHitObject != null)
                        {
                            CrosshairChange(false);
                        }

                        lastHitObject = hit.collider.gameObject;
                        doOnce = false;
                    }

                    if (!doOnce)
                    {
                        CrosshairChange(true);
                    }

                    isCrosshairActive = true;
                    doOnce = true;

                    if (Input.GetKeyDown(KeyCode.E) || hit.collider.CompareTag("Jumpscare"))
                    {
                        target.onRaycastHit.Invoke();
                        target.CheckTasks();
                        if (currentState.AreAllTasksComplete())
                        {
                            AdvanceToNextState();
                        }
                    }
                    break;
                }
            }
        }
        else
        {
            ResetInteraction();
        }
    }

    private void ResetInteraction()
    {
        if (isCrosshairActive && lastHitObject != null)
        {
            CrosshairChange(false);
            doOnce = false;
            lastHitObject = null;
        }
    }

    private void CrosshairChange(bool on)
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

    private void AdvanceToNextState()
    {
        if (currentStateIndex < states.Count - 1)
        {
            currentStateIndex++;
            // Optionally, you could add code here to activate/deactivate objects or perform other state-specific actions.
        }
        else
        {
            Debug.Log("All states completed!");
        }
    }
}
