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
            ESCMenuActivationWithPausingGameProcess();
        }
        else if (CanDisableESCMenu())
        {
            DisableESCMenuWithUnpausingGameProcess();
        }
    }

    private bool CanActiveESCMenu()
    {
        return Input.GetKeyDown(KeyCode.Escape) && content.active == false && settingsMenuContent.active == false;
    }

    private void ESCMenuActivationWithPausingGameProcess()
    {
        GameTimeManager.PauseGame();
        content.SetActive(true);
        CursorManager.UnlockCursor();
    }

    private bool CanDisableESCMenu()
    {
        return Input.GetKeyDown(KeyCode.Escape) && content.active == true;
    }

    private void DisableESCMenuWithUnpausingGameProcess()
    {
        GameTimeManager.UnpauseGame();
        DisableESCMenu();
        CursorManager.LockCursor();
    }

    private void DisableESCMenu()
    {
        content.SetActive(false);
    }

    public void OnSettingsButtonClick()
    {
        settingsMenuContent.SetActive(true);
        DisableESCMenu();
    }

    public void OnExitButtonClick()
    {
        ApplicationManager.ExitApplication();
    }
}
