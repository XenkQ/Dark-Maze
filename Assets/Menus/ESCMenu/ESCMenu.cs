using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenuContent;
    [SerializeField] private GameObject content;

    private void Update()
    {
        if (CanActiveESCMenu())
        {
            ESCMenuActivationProcess();
        }
        else if (CanDisableESCMenu())
        {
            DisableESCMenuProcess();
        }
    }

    private bool CanActiveESCMenu()
    {
        return Input.GetKeyDown(KeyCode.Escape) && content.active == false;
    }

    private void ESCMenuActivationProcess()
    {
        GameTimeManager.PauseGame();
        content.SetActive(true);
        CursorManager.UnlockCursor();
    }

    private bool CanDisableESCMenu()
    {
        return Input.GetKeyDown(KeyCode.Escape) && content.active == true;
    }

    private void DisableESCMenuProcess()
    {
        GameTimeManager.UnpauseGame();
        content.SetActive(false);
        CursorManager.LockCursor();
    }

    public void OnSettingsButtonClick()
    {
        settingsMenuContent.SetActive(true);
        DisableESCMenuProcess();
    }

    public void OnExitButtonClick()
    {
        ApplicationManager.ExitApplication();
    }
}
