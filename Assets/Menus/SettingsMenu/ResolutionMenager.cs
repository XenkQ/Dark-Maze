using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class ResolutionMenager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropDown;
    public static int resolutionIndex;
    private Resolution[] resolutions;

    private void Awake()
    {
        FillResolutionDropBox();
        //SetResolutionSettingsOnStart();
    }

    private void OnEnable()
    {
        SetResolutionSettingsOnStart();
    }

    public void FillResolutionDropBox()
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

        options = options.Distinct().ToList();
        options.Reverse();

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }

    private void SetResolutionSettingsOnStart()
    {
        ChangeResolutionDropDownValue(resolutionIndex);
        SetResolution(resolutionIndex);
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
}
