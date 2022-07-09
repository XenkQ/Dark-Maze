using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class MainMenu : MonoBehaviour, ICanExitGame
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI playText;
    [SerializeField] private TextMeshProUGUI optionsText;
    [SerializeField] private TextMeshProUGUI exitText;

    [Header("Canvases")]
    [SerializeField] private GameObject settingsMenuContent;
    [SerializeField] private GameObject mainMenu;

    [Header("Other Scripts")]
    [SerializeField] private TextInteractionsEffects textInteractionsEffects;

    public void OnButtonClick(Button button)
    {
        switch (button.name)
        {
            case "PlayButton":
                Play();
                break;

            case "OptionsButton":
                ToSettingsMenu();
                break;

            case "ExitButton":
                Exit();
                break;
        }
    }

    private void ToSettingsMenu()
    {
        ResetAllTextColors();
        mainMenu.SetActive(false);
        settingsMenuContent.SetActive(true);
    }

    private void ResetAllTextColors()
    {
        textInteractionsEffects.ResetAllTextColors(new TextMeshProUGUI[] { playText, optionsText, exitText }, textInteractionsEffects.DeafultColor);
    }

    private void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        ApplicationManager.ExitApplication();
    }
}
