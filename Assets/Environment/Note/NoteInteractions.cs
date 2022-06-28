using UnityEngine;

public class NoteInteractions : MonoBehaviour
{
    private CursorManager cursorManager;
    private PlayerCamera playerCamera;
    private bool isfirstEKeyAction = true;

    private void Awake()
    {
        cursorManager = GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManager>();
        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<PlayerCamera>();
    }

    public void InteractWithNote()
    {
        ActionsAfterPlayerSeesNoteAndPressesE();
    }

    private void ActionsAfterPlayerSeesNoteAndPressesE()
    {
        if (Input.GetKeyDown(KeyCode.E) && isfirstEKeyAction == true)
        {
            playerCamera.ZoomIn();
            isfirstEKeyAction = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isfirstEKeyAction == false)
        {
            playerCamera.ReturnToDeafultZoom();
            cursorManager.DisableZoomInteractionCursor();
            isfirstEKeyAction = true;
        }
    }
}
