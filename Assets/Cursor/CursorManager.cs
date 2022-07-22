using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private GameObject zoomCursor;
    [HideInInspector] private bool canEnableInteractionCursor = true;

    private void Awake()
    {
        LockCursor();
        GameTimeManager.UnpauseGame();
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

    public void CanEnableInteractionCursor(bool value)
    {
        canEnableInteractionCursor = value;
    }

    public void EnableInteractionCursor()
    {
        if (zoomCursor.active == false && canEnableInteractionCursor == true)
        {
            zoomCursor.SetActive(true);
        }
    }

    public void DisableInteractionCursor()
    {
        if (zoomCursor.active == true)
        {
            zoomCursor.SetActive(false);
        }
    }

}
