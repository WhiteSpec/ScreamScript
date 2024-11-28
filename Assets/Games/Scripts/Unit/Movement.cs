using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public void Forward(float speed)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Backward(float speed)
    {
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);
    }

    public void Left(float speed)
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void Right(float speed)
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void Jump(Rigidbody rb, float jumpForce)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }
}
