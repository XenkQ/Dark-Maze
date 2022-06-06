using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SettingSaveMenager : MonoBehaviour
{
    private string settingsFilePath;

    private void Awake()
    {
        settingsFilePath = Application.dataPath + "/Saving/settingsFile.json";
        SetSettingsData();
    }
    private class SettingsData
    {
        public int mouseSensitivityValue;
        public float volumeValue;
        public float volumeSliderValue;
        public float volumeTextValue;
        public int resolutionIndex;
        public int qualityIndex;
        public bool fullScreen;
    }

    public void SetSettingsData()
    {
        if (IsSettingsFileExists())
        {
            string jason = File.ReadAllText(settingsFilePath);
            SettingsData loadedSettingsData = JsonUtility.FromJson<SettingsData>(jason);
            MouseSensitivityMenager.mouseSensitivityValue = loadedSettingsData.mouseSensitivityValue;
            VolumeMenager.volumeValue = loadedSettingsData.volumeValue;
            VolumeMenager.volumeSliderValue = loadedSettingsData.volumeSliderValue;
            VolumeMenager.volumeTextValue = loadedSettingsData.volumeTextValue;
            ResolutionMenager.resolutionIndex = loadedSettingsData.resolutionIndex;
            QualityMenager.qualityIndex = loadedSettingsData.qualityIndex;
            FullScreenMenager.isFullScreen = loadedSettingsData.fullScreen;
        }
    }

    public void SaveSettingsData()
    {
        SettingsData settingsData = new SettingsData();
        settingsData.mouseSensitivityValue = MouseSensitivityMenager.mouseSensitivityValue;
        settingsData.volumeValue = VolumeMenager.volumeValue;
        settingsData.volumeSliderValue = VolumeMenager.volumeValue;
        settingsData.volumeTextValue = VolumeMenager.volumeTextValue;
        settingsData.resolutionIndex = ResolutionMenager.resolutionIndex;
        settingsData.qualityIndex = QualityMenager.qualityIndex;
        settingsData.fullScreen = FullScreenMenager.isFullScreen;

        string jason = JsonUtility.ToJson(settingsData);
        Debug.Log(jason);

        File.WriteAllText(settingsFilePath, jason);
    }

    private bool IsSettingsFileExists()
    {
        if (File.Exists(settingsFilePath))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
