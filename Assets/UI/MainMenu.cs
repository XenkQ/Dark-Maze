using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class MainMenu : MonoBehaviour, IMenuButtonEvents
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI playText;
    [SerializeField] private TextMeshProUGUI optionsText;
    [SerializeField] private TextMeshProUGUI exitText;

    [Header("Font")]
    [SerializeField] private int standardFontSize = 15;
    [SerializeField] private int hoveredFontSize = 18;
    [SerializeField] [ColorUsage(true)] private Color32 standardFontColor;
    [SerializeField] [ColorUsage(true)] private Color32 hoveredFontColor;

    [Header("Canvases")]
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject mainMenu;

    [Header("Other Scripts")]
    UIControlsVisualEffects uIControlsVisualEffects = new UIControlsVisualEffects();

    public void OnButtonClick(Button button)
    {
        switch (button.name)
        {
            case "PlayButton":
                Play();
                break;

            case "OptionsButton":
                ToOptions();
                break;

            case "ExitButton":
                Exit();
                break;
        }
    }

    public void OnButtonEnter(Button button)
    {
        FontHoveredEffect(button);
    }

    public void OnButtonExit(Button button)
    {
        FontExitEffect(button);
    }

    private void FontHoveredEffect(Button button)
    {
        TextMeshProUGUI text = button.transform.GetComponentInChildren<TextMeshProUGUI>();
        uIControlsVisualEffects.ChangeFontSize(text, hoveredFontSize);
        uIControlsVisualEffects.ChangeFontColor(text, hoveredFontColor);
    }

    private void FontExitEffect(Button button)
    {
        TextMeshProUGUI text = button.transform.GetComponentInChildren<TextMeshProUGUI>();
        uIControlsVisualEffects.ChangeFontSize(text, standardFontSize);
        uIControlsVisualEffects.ChangeFontColor(text, standardFontColor);
    }

    private void ResetAllTextColors()
    {
        uIControlsVisualEffects.ResetAllTextColors(new TextMeshProUGUI[] { playText, optionsText, exitText}, standardFontColor);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ToOptions()
    {
        ResetAllTextColors();
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
