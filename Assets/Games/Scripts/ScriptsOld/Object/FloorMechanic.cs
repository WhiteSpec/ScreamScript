using System.Collections;
using UnityEngine;

public class FloorMechanic : MonoBehaviour
{
    public GameObject step;
    public GameObject player;
    public float fadeDuration = 1.0f;
    public float moveDuration = 1.0f;

    private Vector3 originalPosition;
    private Renderer stepRenderer;
    private Color originalColor;

    void Start()
    {
        if (step == null)
        {
            Debug.LogError("Step GameObject is not assigned.");
            return;
        }

        stepRenderer = step.GetComponent<Renderer>();
        if (stepRenderer == null)
        {
            Debug.LogError("Step GameObject does not have a Renderer component.");
            return;
        }

        originalPosition = step.transform.position;
        step.transform.position = new Vector3(originalPosition.x, originalPosition.y - 1f, originalPosition.z);

        originalColor = stepRenderer.material.color;
        Color transparentColor = originalColor;
        transparentColor.a = 0f;
        stepRenderer.material.color = transparentColor;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            StartCoroutine(FadeInAndMove());
        }
    }

    private IEnumerator FadeInAndMove()
    {
        float elapsedTime = 0f;
        Vector3 startPos = step.transform.position;
        Color startColor = stepRenderer.material.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
            stepRenderer.material.color = Color.Lerp(startColor, originalColor, t);
            step.transform.position = Vector3.Lerp(startPos, originalPosition, t);
            yield return null;
        }

        // Ensure the final state is set correctly
        stepRenderer.material.color = originalColor;
        step.transform.position = originalPosition;
    }
}
