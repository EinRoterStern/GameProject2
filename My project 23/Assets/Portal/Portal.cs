using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal Other;
    public Camera PortalView;
    public Vector3 CameraOffset = new Vector3(0, -0.5f, 0); // Обновленное смещение камеры

    private void Start()
    {
        Other.PortalView.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        GetComponentInChildren<MeshRenderer>().sharedMaterial.mainTexture = Other.PortalView.targetTexture;
    }

    private void Update()
    {
        // Position
        PortalView.transform.position = transform.position + CameraOffset; // Используйте смещение камеры

        // Rotation
        Quaternion difference = transform.rotation * Quaternion.Inverse(Other.transform.rotation * Quaternion.Euler(0, 0, 0));
        PortalView.transform.rotation = difference * Camera.main.transform.rotation;

        // Clipping
        PortalView.nearClipPlane = 0.01f;
    }
}