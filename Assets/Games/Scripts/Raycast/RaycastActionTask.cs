using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class RaycastActionTask
{
    public string taskName;            // Name of the task
    public bool isComplete = false;    // Status of the task
    public UnityEvent onTaskComplete;  // Event to trigger when the task is completed
}
