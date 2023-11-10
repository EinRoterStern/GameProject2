using System;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter Other;

    private void Start()
    {
        
    }
    
    private void Update()
    {
        
    }

    private void Teleport(Transform obj)
    {
        // Position
        Vector3 localPos = Other.transform.worldToLocalMatrix.MultiplyPoint3x4(obj.position);
        localPos = new Vector3(-localPos.x, localPos.y, -localPos.z);
        obj.position = transform.localToWorldMatrix.MultiplyPoint3x4(localPos);

        // Rotation
        Quaternion relativeRotation = Quaternion.Inverse(Other.transform.rotation) * obj.rotation;
        obj.rotation = transform.rotation * relativeRotation;
    }
}
