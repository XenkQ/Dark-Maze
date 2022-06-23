using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseSensitivityManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sensitivityText;
    [SerializeField] private Slider sensitivitySlider;
    public const float MOUSE_SENSITIVITY_MULTIPLER = 0.5f;
    public static int mouseSensitivityValue = 3;

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
    }
}
