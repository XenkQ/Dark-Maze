using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QualityManager : MonoBehaviour
{
    [Header("Quality")]
    [SerializeField] private TMP_Dropdown qualityDropDown;
    public static int qualityIndex;

    private void Awake()
    {
        //SetQualitySettingsOnStart();
    }

    private void OnEnable()
    {
        SetQualitySettingsOnStart();
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
}
