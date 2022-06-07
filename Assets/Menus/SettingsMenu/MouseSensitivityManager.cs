using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseSensitivityManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sensitivityText;
    [SerializeField] private Slider sensitivitySlider;
    public static int mouseSensitivityValue;

    private void Awake()
    {
        SetMouseSettings();
    }

    private void SetMouseSettings()
    {
        sensitivitySlider.value = mouseSensitivityValue;
        OnSensitivityChange();
    }

    public void OnSensitivityChange()
    {
        mouseSensitivityValue = Mathf.RoundToInt(sensitivitySlider.value);
        sensitivityText.text = mouseSensitivityValue.ToString();
        MouseLook.mouseSensitivity = mouseSensitivityValue;
    }
}
