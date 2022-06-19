using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI backButtonText;
    [SerializeField] private TextMeshProUGUI saveButtonText;

    [Header("Canvases")]
    [SerializeField] private GameObject settingsMenuContent;
    [SerializeField] private GameObject backToMenuContent;

    [Header("Other Scripts")]
    [SerializeField] private SettingSaveManager settingSaveMenager;
    [SerializeField] private TextInteractionsEffects textInteractionsEffects;

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

    private void ToMenu()
    {
        ResetAllTextColors();
        settingsMenuContent.SetActive(false);
        backToMenuContent.SetActive(true);
    }

    private void ResetAllTextColors()
    {
        textInteractionsEffects.ResetAllTextColors(new TextMeshProUGUI[] { backButtonText, saveButtonText }, textInteractionsEffects.DeafultColor);
    }
}
