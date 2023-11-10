using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter Other;

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

        // Use the position of the Other Teleporter
        Vector3 localPos = Other.transform.worldToLocalMatrix.MultiplyPoint3x4(obj.position);
        localPos = new Vector3(-(localPos.x), localPos.y, -(localPos.z));

        // Adjust the y-coordinate based on the height of your world
        float worldHeight = 20.0f; // Update with the actual height of your world
        localPos.y = Mathf.Clamp(localPos.y, 0, worldHeight);

        Vector3 newPosition = Other.transform.localToWorldMatrix.MultiplyPoint3x4(localPos) + Other.transform.forward * 5.0f;

        // Set the new position
        obj.position = newPosition;

        // Set the new rotation
        obj.rotation = Other.transform.rotation * Quaternion.Euler(0, 180, 0);
    }
}