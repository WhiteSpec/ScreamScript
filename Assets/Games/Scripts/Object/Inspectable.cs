using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspectable : Object_
{
    public string Description;

    public void ShowName()
    {
        Debug.Log(name);
    }

    public void ShowDescription()
    {
        Debug.Log(Description);
    }
}
