using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysSeePlayer : MonoBehaviour
{

    public Transform player;  // Reference to the player's transform

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is assigned
        if (player != null)
        {
            // Calculate the direction from this object to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Zero out the Y component to rotate vertically only
            directionToPlayer.y = 0;

            // Calculate the rotation needed to look at the player
            Quaternion rotation = Quaternion.LookRotation(directionToPlayer);

            // Apply the rotation to the object, keeping the X rotation fixed at 90 degrees
            transform.rotation = Quaternion.Euler(90, rotation.eulerAngles.y, 0);
        }
    }
}
