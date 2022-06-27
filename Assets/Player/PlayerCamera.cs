using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float zoomInValue = 30;
    [SerializeField] private float zoomOutValue = 60;
    private Camera playerCamera;

    private void Awake()
    {
        playerCamera = GetComponent<Camera>();
    }

    public Camera GetPlayerCamera()
    {
        return playerCamera;
    }

    public void ZoomIn()
    {
        playerCamera.fieldOfView = zoomInValue;
    }

    public void ZoomOut()
    {
        playerCamera.fieldOfView = zoomOutValue;
    }
}
