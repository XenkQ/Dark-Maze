using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ESCMenu : MonoBehaviour, ICanExitGame
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI toSettingsText;
    [SerializeField] private TextMeshProUGUI exitText;

    [Header("Contents of menus")]
    [SerializeField] private GameObject settingsMenuContent;
    [SerializeField] private GameObject content;

    [Header("Other Scripts")]
    [SerializeField] private TextInteractionsEffects textInteractionsEffects;
    [SerializeField] private InLvlPostProcessingManager inLvlPostProcessingManager;
    [SerializeField] private PlayerInteractions playerInteractions;
    private FleshLight fleshLight;
    private PlayerCamera playerCamera;

    private void Awake()
    {
        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<PlayerCamera>();
        fleshLight = GameObject.FindGameObjectWithTag("FleshLight").GetComponent<FleshLight>();
    }

    private void Update()
    {
        if (CanActiveESCMenu())
        {
            GameTimeManager.PauseGame();
            playerInteractions.StopInteractions();
            fleshLight.PauseFleshLightActions();
            ESCMenuContentActivationProcess();
            CursorManager.UnlockCursor();
        }
        else if (CanDisableESCMenu())
        {
            GameTimeManager.UnpauseGame();
            playerInteractions.ResumeInteractions();
            fleshLight.UnpauseFleshLightActions();
            DisableESCMenuContentProcess();
            CursorManager.LockCursor();
        }
    }

    private bool CanActiveESCMenu()
    {
        return Input.GetKeyDown(KeyCode.Escape) && content.active == false && settingsMenuContent.active == false;
    }

    private void ESCMenuContentActivationProcess()
    {
        inLvlPostProcessingManager.ActiveDepthOfFieldEffect(true);
        content.SetActive(true);
        playerCamera.DisableCameraRotationScript();
    }

    private bool CanDisableESCMenu()
    {
        return Input.GetKeyDown(KeyCode.Escape) && content.active == true;
    }

    private void DisableESCMenuContentProcess()
    {
        ResetAllTextColors();
        inLvlPostProcessingManager.ActiveDepthOfFieldEffect(false);
        content.SetActive(false);
        playerCamera.EnableCameraRotationScript();
    }

    private void DisableESCMenu()
    {
        content.SetActive(false);
    }

    public void OnSettingsButtonClick()
    {
        ResetAllTextColors();
        settingsMenuContent.SetActive(true);
        DisableESCMenu();
    }

    private void ResetAllTextColors()
    {
        textInteractionsEffects.ResetAllTextColors(new TextMeshProUGUI[] { toSettingsText, exitText }, textInteractionsEffects.DeafultColor);
    }

    public void Exit()
    {
        ApplicationManager.ExitApplication();
    }
}
