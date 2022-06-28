using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float defaultZoomValue = 60;
    [SerializeField] private float zoomInValue = 30;
    [SerializeField] private float zoomOutValue = 70;

    private bool isDefaultZoom = true;
    public bool IsDeafultZoom { get { return isDefaultZoom; } }
    private bool isZoomedIn = false;
    public bool IsZoomedIn { get { return isZoomedIn; } }
    private bool isZoomedOut = false;
    public bool IsZoomedOut { get { return isZoomedOut; } }

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
        if (isZoomedIn == false)
        {
            playerCamera.fieldOfView = zoomInValue;
            isZoomedIn = true;
            isDefaultZoom = false;
            isZoomedOut = false;
        }
    }

    public void ZoomOut()
    {
        if (isZoomedOut == false)
        {
            playerCamera.fieldOfView = zoomOutValue;
            isZoomedOut = true;
            isDefaultZoom = false;
            isZoomedOut = false;
        }
    }

    public void ReturnToDeafultZoom()
    {
        if (isDefaultZoom == false)
        {
            playerCamera.fieldOfView = defaultZoomValue;
            isDefaultZoom = true;
            isZoomedOut = false;
            isZoomedIn = false;
        }
    }
}
