using UnityEngine;

[RequireComponent(typeof(Note))]
public class NoteInteractions : MonoBehaviour
{
    private CursorManager cursorManager;
    private PlayerCamera playerCamera;
    private bool isfirstEKeyAction = true;
    private Note note;
    private NoteUI noteUI;

    private void Awake()
    {
        note = GetComponent<Note>();
        noteUI = GameObject.FindGameObjectWithTag("NoteUI").GetComponent<NoteUI>();
        cursorManager = GameObject.FindGameObjectWithTag("CursorManager").GetComponent<CursorManager>();
        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<PlayerCamera>();
    }

    public void InteractWithNote()
    {
        ActionsAfterPlayerSeesNoteAndPressesE();
    }

    private void ActionsAfterPlayerSeesNoteAndPressesE()
    {
        if (CanActiveNotePreview())
        {
            noteUI.ActiveContentWithNewText(note.Text);
            GameTimeManager.PauseGame();
            cursorManager.CanEnableInteractionCursor = false;
            cursorManager.DisableInteractionCursor();
            playerCamera.DisableCameraRotationScript();
            isfirstEKeyAction = false;
        }
        else if (CanExitFromNotePreview())
        {
            noteUI.DisableContent();
            GameTimeManager.UnpauseGame();
            cursorManager.CanEnableInteractionCursor = true;
            playerCamera.EnableCameraRotationScript();
            isfirstEKeyAction = true;
        }
    }

    private bool CanActiveNotePreview()
    {
        return Input.GetKeyDown(KeyCode.E) && isfirstEKeyAction == true;
    }

    private bool CanExitFromNotePreview()
    {
        return Input.GetKeyDown(KeyCode.E) && isfirstEKeyAction == false;
    }
}
