using System.Collections;
using UnityEngine;

public class JS_Movement : JumpScare
{
    public GameObject scareObjectPrefab;  
    public Transform startPoint;          
    public Transform endPoint;           
    public float moveSpeed = 5f;         

    private GameObject scareObject;      

    public override void TriggerJumpScare()
    {
        base.TriggerJumpScare();
        SpawnAndMoveObject();
    }

    private void SpawnAndMoveObject()
    {
        if (scareObjectPrefab != null && startPoint != null)
        {
            scareObject = Instantiate(scareObjectPrefab, startPoint.position, startPoint.rotation);
            StartCoroutine(MoveObjectToPoint(scareObject, endPoint.position));
        }
        else
        {
            Debug.LogWarning("Scare object prefab or start point is not assigned.");
        }
    }

    private IEnumerator MoveObjectToPoint(GameObject obj, Vector3 targetPoint)
    {
        while (obj != null && Vector3.Distance(obj.transform.position, targetPoint) > 0.1f)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPoint, moveSpeed * Time.deltaTime);
            yield return null;
        }

        EndJumpScare();
    }

    protected override void EndJumpScare()
    {
        base.EndJumpScare();

        if (scareObject != null)
        {
            Destroy(scareObject);
        }
    }
}
