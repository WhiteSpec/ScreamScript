using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player is not assigned!");
            return;
        }

        // Calculate the distance in X and Z directions
        float distanceX = Mathf.Abs(player.position.x - transform.position.x);
        float distanceZ = Mathf.Abs(player.position.z - transform.position.z);
        int intDistanceX = Mathf.FloorToInt(distanceX);
        int intDistanceZ = Mathf.FloorToInt(distanceZ);
        // Print the distances in the console
        Debug.Log("Distance to player in X direction: " + intDistanceX);
        Debug.Log("Distance to player in Z direction: " + intDistanceZ);
    }
}
