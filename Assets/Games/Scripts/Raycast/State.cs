using System.Collections.Generic;

[System.Serializable]
public class State
{
    public string stateName;                       // Name of the state
    public List<RaycastActionTarget> actionTargets; // List of action targets within this state

    public bool AreAllTasksComplete()
    {
        foreach (var target in actionTargets)
        {
            foreach (var task in target.tasks)
            {
                if (!task.isComplete)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
