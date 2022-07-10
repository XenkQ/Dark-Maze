using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI backButtonText;

    [Header("Canvases")]
    [SerializeField] private GameObject settingsMenuContent;
    [SerializeField] private GameObject overridingContent;

    [Header("Other Scripts")]
    [SerializeField] private SettingSaveManager settingSaveMenager;
    [SerializeField] private TextInteractionsEffects textInteractionsEffects;

    public void ToOverridingContent()
    {
        ResetAllTextColors();
        settingsMenuContent.SetActive(false);
        overridingContent.SetActive(true);
    }

    private void ResetAllTextColors()
    {
        textInteractionsEffects.ResetAllTextColors(new TextMeshProUGUI[] { backButtonText}, textInteractionsEffects.DeafultColor);
    }
}
