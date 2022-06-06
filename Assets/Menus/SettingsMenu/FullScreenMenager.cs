using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenMenager : MonoBehaviour
{
    [SerializeField] private Toggle fullScreenToggle;
    public static bool isFullScreen;

    private void Awake()
    {
        //SettFullScreenSettingsOnStart();
    }

    private void OnEnable()
    {
        SettFullScreenSettingsOnStart();
    }

    private void SettFullScreenSettingsOnStart()
    {
        ChangeFullScreenToggleValue(isFullScreen);
        SetFullScreen(isFullScreen);
    }

    private void ChangeFullScreenToggleValue(bool isFullScreen)
    {
        fullScreenToggle.isOn = isFullScreen;
        SetFullScreen(isFullScreen);
    }

    public void SetFullScreen(bool _isFullScreen)
    {
        Screen.fullScreen = _isFullScreen;
        isFullScreen = _isFullScreen;
    }
}
