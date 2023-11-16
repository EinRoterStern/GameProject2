using System.Collections;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter Other;
    public float offsetDistance = 1.0f; // Добавьте это поле для управления смещением
    public float disableTime = 1.0f; // Время отключения триггера после телепортации
    private Collider myCollider;

    private void Start()
    {
        myCollider = GetComponent<Collider>();
    }

    private void OnTriggerStay(Collider other)
    {
        float zPos = transform.InverseTransformPoint(other.transform.position).z;

        if (zPos < 0)
        {
            Teleport(other.transform);
        }
    }

    private void Teleport(Transform obj)
    {
        if (Other == null)
        {
            Debug.LogError("Other Teleporter is not assigned.");
            return;
        }

        // Set the new position with a forward offset
        obj.position = Other.transform.position + obj.forward * offsetDistance; 

        // Set the new rotation
        obj.rotation = Other.transform.rotation;

        // Disable the Other's collider for a short time
        StartCoroutine(DisableCollider(Other.myCollider));
    }
    private IEnumerator DisableCollider(Collider collider)
    {
        collider.enabled = false;
        yield return new WaitForSeconds(disableTime);
        collider.enabled = true;
    }
}