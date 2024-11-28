using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class RaycastActionTarget
{
    public GameObject targetObject;             // Object to interact with
    public List<RaycastActionTask> tasks;       // List of tasks associated with this target
    public UnityEvent onRaycastHit;             // Event to trigger on raycast hit

    public void CheckTasks()
    {
        foreach (var task in tasks)
        {
            if (!task.isComplete)
            {
                task.isComplete = true;
                task.onTaskComplete.Invoke();
            }
        }
    }
}
