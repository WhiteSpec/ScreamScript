using System.Collections;
using UnityEngine;

public class JS_Idle : JumpScare
{
    public GameObject scareObjectPrefab;  
    public Transform spawnPoint;          
    public Transform cameraTransform;     
    public float rotationSpeed = 2f;      

    private GameObject scareObject;       

    public override void TriggerJumpScare()
    {
        base.TriggerJumpScare();
        SpawnAndScare();
    }

    private void SpawnAndScare()
    {
        if (scareObjectPrefab != null && spawnPoint != null)
        {
            scareObject = Instantiate(scareObjectPrefab, spawnPoint.position, spawnPoint.rotation);
            StartCoroutine(ScareCoroutine());
        }
        else
        {
            Debug.LogWarning("Scare object prefab or spawn point is not assigned.");
        }
    }

    private IEnumerator ScareCoroutine()
    {
        if (cameraTransform != null && scareObject != null)
        {
            Quaternion initialRotation = cameraTransform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(scareObject.transform.position - cameraTransform.position);

            float elapsedTime = 0f;
            while (elapsedTime < 2f)
            {
                cameraTransform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / 2f * rotationSpeed);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            cameraTransform.rotation = targetRotation;
        }

        yield return new WaitForSeconds(2f);

        if (scareObject != null)
        {
            Destroy(scareObject);
        }
    }
}
