using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    private int phase = 3;
    public int isPhase;
    public GameObject player;
    public GameObject item1;
    public GameObject item2;

    void Start()
    {
        isPhase = 1;
    }

    void Update()
    {
        if(isPhase == 1)
        {
            ObjectController controller = item1.GetComponent<ObjectController>();
            if(controller.isDialogueDone != false )
            {
                isPhase = 2;
            }
        }
        else if (isPhase == 2)
        {
            ObjectController controller = item2.GetComponent<ObjectController>();
            if (controller.isDialogueDone != false)
            {
                isPhase = 3;
            }
        }
    }
}
