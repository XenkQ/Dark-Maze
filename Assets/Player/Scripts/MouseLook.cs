using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivityMultipler = 100f;
    public static float mouseSensitivity;
    private Transform playerTransform;
    private float xRotarion = 0f;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        Screen.lockCursor = true;
        MouseSensitivityCheck();
    }

    private void Update()
    {
        MoveCamera();
    }

    //TODO: Maybe change?
    private static void MouseSensitivityCheck()
    {
        if (mouseSensitivity < 1f)
        {
            mouseSensitivity = 5f;
        }
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
