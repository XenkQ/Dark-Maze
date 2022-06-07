using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenManager : MonoBehaviour
{
    [SerializeField] private Toggle fullScreenToggle;
    public static bool isFullScreen;

    private void Awake()
    {
        SettFullScreenSettings();
    }

    private void SettFullScreenSettings()
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
