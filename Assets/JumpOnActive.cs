using UnityEngine;

public class JumpOnActive : MonoBehaviour
{
    public float jumpPower = 10f;  // The power of the jump
    private Rigidbody rb;  // Reference to the Rigidbody component

    // Called when the object becomes active
    public void OnEnable()
    {
        // Get the Rigidbody component attached to the object
        rb = GetComponent<Rigidbody>();

        // Ensure the Rigidbody is found and apply the jump force
        if (rb != null)
        {
            // Apply an upward force to the Rigidbody to make the object jump
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        else
        {
            Debug.LogWarning("No Rigidbody component found on this object.");
        }
    }
}
