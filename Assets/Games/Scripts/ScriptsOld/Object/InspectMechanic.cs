using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectMechanic : MonoBehaviour
{
    public GameObject objectNameBG;
    public Text objectNameUI;

    public float onScreenTimer;
    public GameObject objectDialogueBG;
    public Text objectDialogueUI;
    public bool startTimer;
    private float timer;

    private void Start()
    {
        objectNameBG.SetActive(false);
        objectDialogueBG.SetActive(false);
    }

    private void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 0;
                HideObjectDialogue();
                startTimer = false;
            }
        }
    }

    public void ShowObjectName(string objectName)
    {
        objectNameBG.SetActive(true);
        objectNameUI.text = objectName;
    }

    public void HideObjectName()
    {
        objectNameBG.SetActive(false);
        objectNameUI.text = "";
    }

    public void ShowObjectDialogue(string objectDialogue)
    {
        timer = onScreenTimer;
        startTimer = true;
        objectDialogueBG.SetActive(true);
        objectDialogueUI.text = objectDialogue;
    }

    public void HideObjectDialogue()
    {
        objectDialogueBG.SetActive(false);
        objectDialogueUI.text = "";
    }
}
