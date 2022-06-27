using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInteractions : MonoBehaviour
{
    private CursorManager cursorManager;
    private PlayerCamera playerCamera;

    private void Awake()
    {
        cursorManager = GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManager>();
        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<PlayerCamera>();
    }

    public void InteractWithNote()
    {
        cursorManager.EnableZoomInteractionCursor();

        ActionsAfterPlayerSeesNoteAndPressesE();

        //else
        //{
        //    cursorManager.DisableZoomInteractionCursor();
        //    playerCamera.ZoomOut();
        //}
    }

    private void ActionsAfterPlayerSeesNoteAndPressesE()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerCamera.ZoomIn();
        }
    }
}
