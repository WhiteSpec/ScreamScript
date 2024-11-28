using UnityEngine;

public class TriggerOnTouch : MonoBehaviour
{
    // Variables that can be customized in the Inspector
    public string triggeringTag = "Player";  // Tag to check for triggering
    public string messageToShow = "Player has touched the collider and the script is activated!";
    public bool playSound = false;  // Option to play a sound
    public AudioClip soundClip;     // Sound to play
    public GameObject objectToActivate; // Object to activate or deactivate
    public bool destroyAfterActivation = true; // Option to destroy this object after activation

    // Called when another object enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the collider has the correct tag
        if (other.CompareTag(triggeringTag))
        {
            // Display the message in the console
            Debug.Log(messageToShow);

            // Play a sound if the option is enabled and a sound clip is assigned
            if (playSound && soundClip != null)
            {
                AudioSource.PlayClipAtPoint(soundClip, transform.position);
            }

            // Activate or deactivate the specified object if assigned
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(!objectToActivate.activeSelf);
            }

            // Destroy this object if the option is enabled
            if (destroyAfterActivation)
            {
                Destroy(gameObject);
            }
        }
    }
}
