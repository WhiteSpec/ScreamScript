using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public string objectName;
    public bool isDialogueDone = false;
    
    [TextArea] public string objectDialogue;

    public InspectMechanic inspectMechanic;

    public void ShowObjectName()
    {
        inspectMechanic.ShowObjectName(objectName);
    }
    public void HideObjectName()
    {
        inspectMechanic.HideObjectName();
    }
    public void ShowObjectDialogue()
    {
        inspectMechanic.ShowObjectDialogue(objectDialogue);
        isDialogueDone = true;
    }
    public void HideObjectDialogue()
    {
        inspectMechanic.HideObjectDialogue();
    }
}
