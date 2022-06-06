using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//TODO: CLASS FOR REFACTORING
public class SettingsMenu : MonoBehaviour, IMenuButtonEvents
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI backButtonText;
    [SerializeField] private TextMeshProUGUI saveButtonText;

    [Header("Font")]
    [SerializeField] private int standardFontSize = 80;
    [SerializeField] private int hoveredFontSize = 83;
    [SerializeField] [ColorUsage(true)] private Color32 standardFontColor;
    [SerializeField] [ColorUsage(true)] private Color32 hoveredFontColor;

    [Header("Canvases")]
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject mainMenu;

    [Header("Other Scripts")]
    [SerializeField] SettingSaveMenager settingSaveMenager;
    UIControlsVisualEffects uIControlsVisualEffects = new UIControlsVisualEffects();

    public void OnButtonClick(Button button)
    {
        switch (button.name)
        {
            case "BackButton":
                ToMenu();
                break;

            case "SaveButton":
                settingSaveMenager.SaveSettingsData();
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

    public void ToMenu()
    {
        ResetAllTextColors();
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    private void ResetAllTextColors()
    {
        uIControlsVisualEffects.ResetAllTextColors(new TextMeshProUGUI[] { backButtonText, saveButtonText }, standardFontColor);
    }
}
