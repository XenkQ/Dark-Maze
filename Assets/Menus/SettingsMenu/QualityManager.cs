using UnityEngine;
using TMPro;

public class QualityManager : MonoBehaviour
{
    [Header("Quality")]
    [SerializeField] private TMP_Dropdown qualityDropDown;
    public static int qualityIndex = 1;

    private void Awake()
    {
        SetQualitySettings();
    }

    private void SetQualitySettings()
    {
        ChangeQualityDropDownValue(qualityIndex);
        SetQuality(qualityIndex);
    }

    private void ChangeQualityDropDownValue(int qualityIndex)
    {
        qualityDropDown.value = qualityIndex;
        SetQuality(qualityIndex);
    }

    public void SetQuality(int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel);
        qualityIndex = qualityLevel;
    }
}
