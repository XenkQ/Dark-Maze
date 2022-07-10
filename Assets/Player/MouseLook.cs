using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float xRotarion = 0f;
    private Transform playerTransform;
    [SerializeField] private Map map;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (CanMoveCamera())
        {
            MoveCamera();
        }
    }

    private void MoveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivityManager.mouseSensitivityValue * MouseSensitivityManager.MOUSE_SENSITIVITY_MULTIPLER;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivityManager.mouseSensitivityValue * MouseSensitivityManager.MOUSE_SENSITIVITY_MULTIPLER;

        xRotarion -= mouseY;
        xRotarion = Mathf.Clamp(xRotarion, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotarion, 0, 0);
        playerTransform.Rotate(Vector3.up * mouseX);
    }

    private bool CanMoveCamera()
    {
        return !map.IsVisible();
    }
}
