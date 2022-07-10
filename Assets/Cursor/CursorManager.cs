using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private GameObject zoomCursor;

    private void Awake()
    {
        LockCursor();
    }

    public static void UnlockCursor()
    {
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public static void LockCursor()
    {
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void EnableZoomInteractionCursor()
    {
        if (zoomCursor.active == false)
        {
            zoomCursor.SetActive(true);
        }
    }

    public void DisableZoomInteractionCursor()
    {
        if (zoomCursor.active == true)
        {
            zoomCursor.SetActive(false);
        }
    }
}
