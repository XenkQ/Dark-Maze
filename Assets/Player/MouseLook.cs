using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivityMultipler = 100f;
    public static float mouseSensitivity = 7;
    private Transform playerTransform;
    private float xRotarion = 0f;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        CursorManager.LockCursor();
    }

    private void Update()
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
