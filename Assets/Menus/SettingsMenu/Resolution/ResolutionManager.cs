using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropDown;

    // (1920x1080),(1536x864),(1440x900),(1366x768), (1024x768)
    [SerializeField] private Resolution[] resolutions;
    public static int resolutionIndex = 0;

    private void Awake()
    {
        FillResolutionDropBox();
        SetResolutionSettings();
    }

    public void FillResolutionDropBox()
    {
        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = $"{resolutions[i].width}x{resolutions[i].height}";
            options.Add(option);
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = 0;
        resolutionDropDown.RefreshShownValue();
    }

    private void SetResolutionSettings()
    {
        ChangeResolutionDropDownValue(resolutionIndex);
        SetResolution(resolutionIndex);
    }

    private void ChangeResolutionDropDownValue(int resolutionIndex)
    {
        resolutionDropDown.value = resolutionIndex;
        SetResolution(resolutionIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, FullScreenManager.isFullScreen);
    }
}
