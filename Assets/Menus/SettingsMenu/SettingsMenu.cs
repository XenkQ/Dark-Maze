using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

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

    [Header("Mouse Sensitivity")]
    [SerializeField] private TextMeshProUGUI sensitivityText;
    [SerializeField] private Slider sensitivitySlider;
    public static int mouseSensitivityValue;

    [Header("Resolution")]
    [SerializeField] private TMP_Dropdown resolutionDropDown;
    public static int resolutionIndex;
    private Resolution[] resolutions;

    [Header("Quality")]
    [SerializeField] private TMP_Dropdown qualityDropDown;
    public static int qualityIndex;

    [Header("Volume")]
    [SerializeField] private TextMeshProUGUI volumeText;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;
    public static float volumeValue;
    public static float volumeTextValue;
    public static float volumeSliderValue;

    [Header("FullScreen")]
    [SerializeField] private Toggle fullScreenToggle;
    public static bool isFullScreen;

    [Header("Other Scripts")]
    [SerializeField] private Saving saving;
    UIControlsVisualEffects uIControlsVisualEffects = new UIControlsVisualEffects();

    private void Awake()
    {
        FillResolutionDropBox();
        SetSettingsValues();
    }

    public void OnButtonClick(Button button)
    {
        switch (button.name)
        {
            case "BackButton":
                ToMenu();
                break;

            case "SaveButton":
                SaveSettings();
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

    private void SetSettingsValues()
    {
        if(saving.isSettingsFileExists())
        {
            SetMouseSettingsOnStart();

            //TODO: Make readable from jason
            volumeText.text = volumeTextValue.ToString();
            volumeSlider.value = volumeSliderValue;
            Debug.Log(volumeValue);
            audioMixer.ClearFloat("volume");
            SetVolume(volumeValue);

            //TODO: Make working out of settings
            SetResolutionSettingsOnStart();
            SetQualitySettingsOnStart();
            SettFullScreenSettingsOnStart();
        }
    }

    private void SettFullScreenSettingsOnStart()
    {
        ChangeFullScreenToggleValue(isFullScreen);
        SetFullScreen(isFullScreen);
    }

    private void SetResolutionSettingsOnStart()
    {
        ChangeResolutionDropDownValue(resolutionIndex);
        SetResolution(resolutionIndex);
    }

    private void SetMouseSettingsOnStart()
    {
        sensitivitySlider.value = mouseSensitivityValue;
        OnSensitivityChange();
    }

    private void ChangeFullScreenToggleValue(bool isFullScreen)
    {
        fullScreenToggle.isOn = isFullScreen;
        SetFullScreen(isFullScreen);
    }

    private void SetQualitySettingsOnStart()
    {
        ChangeQualityDropDownValue(qualityIndex);
        SetQuality(qualityIndex);
    }

    private void ChangeQualityDropDownValue(int qualityIndex)
    {
        qualityDropDown.value = qualityIndex;
        SetQuality(qualityIndex);
    }

    public void SetQuality(int _qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        qualityIndex = _qualityIndex;
    }

    private void FillResolutionDropBox()
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = $"{resolutions[i].width} X {resolutions[i].height}";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].width == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        options.Reverse();

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }

    private void ChangeResolutionDropDownValue(int resolutionIndex)
    {
        resolutionDropDown.value = resolutionIndex;
        SetResolution(resolutionIndex);
    }

    public void SetResolution(int _resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        resolutionIndex = _resolutionIndex;
    }

    public void OnVolumeChange()
    {
        float value = volumeSlider.value;
        volumeSliderValue = value;
        volumeText.text = Mathf.Round(value * 100).ToString();
        volumeTextValue = int.Parse(volumeText.text);
        value = Mathf.Log10(value) * 20;
        volumeValue = value;
        SetVolume(value);
    }

    public void SetVolume(float volumeValue)
    {
        audioMixer.SetFloat("volume", volumeValue);
    }
    public void OnSensitivityChange()
    {
        mouseSensitivityValue = Mathf.RoundToInt(sensitivitySlider.value);
        sensitivityText.text = mouseSensitivityValue.ToString();
        MouseLook.mouseSensitivity = mouseSensitivityValue;
    }

    public void ToMenu()
    {
        ResetAllTextColors();
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void SaveSettings()
    {
        saving.SaveSettingsData(
            mouseSensitivityValue,
            volumeValue,
            volumeSliderValue,
            volumeTextValue,
            resolutionIndex,
            qualityIndex,
            isFullScreen
        );
    }

    private void ResetAllTextColors()
    {
        uIControlsVisualEffects.ResetAllTextColors(new TextMeshProUGUI[] { backButtonText, saveButtonText}, standardFontColor);
    }

    public void SetFullScreen(bool _isFullScreen)
    {
        Screen.fullScreen = _isFullScreen;
        isFullScreen = _isFullScreen;
    }

}
