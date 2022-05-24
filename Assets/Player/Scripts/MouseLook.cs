using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public static float mouseSensitivity;
    [SerializeField] private float mouseSensitivityMultipler = 100f;
    private Transform playerTransform;
    private float xRotarion = 0f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Screen.lockCursor = true;
        MouseSensitivityCheck();
    }

    private static void MouseSensitivityCheck()
    {
        if (mouseSensitivity < 1f)
        {
            mouseSensitivity = 5f;
        }
    }

    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime * mouseSensitivityMultipler;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * mouseSensitivityMultipler;

        xRotarion -= mouseY;
        xRotarion = Mathf.Clamp(xRotarion, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotarion, 0, 0);
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
