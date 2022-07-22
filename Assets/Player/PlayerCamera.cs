using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerCamera : MonoBehaviour
{
    private Camera playerCamera;
    private MouseLook mouseLook;

    private void Awake()
    {
        playerCamera = GetComponent<Camera>();
        mouseLook = GetComponent<MouseLook>();
    }

    public Camera GetPlayerCamera()
    {
        return playerCamera;
    }

    public void DisableCameraRotationScript()
    {
        if(mouseLook.enabled == true)
        {
            mouseLook.enabled = false;
        }
    }

    public void EnableCameraRotationScript()
    {
        if (mouseLook.enabled == false)
        {
            mouseLook.enabled = true;
        }
    }
}
