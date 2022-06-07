using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SettingSaveManager : MonoBehaviour
{
    private string settingsFilePath;
    private string directoryPath;

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

    private void Awake()
    {
        settingsFilePath = Application.dataPath + "/Saving/settingsFile.json";
        directoryPath = Application.dataPath + "/Saving";
        CreateSaveDirectoryIfNotExists();
        SetSettingsDataProcess();
    }

    private void CreateSaveDirectoryIfNotExists()
    {
        if (!IsSaveDirectoryExist())
        {
            Directory.CreateDirectory(directoryPath);
        }
    }

    public void SetSettingsDataProcess()
    {
        if (IsSettingsFileExists())
        {
            SetSettings();
        }
    }

    private void SetSettings()
    {
        string jason = File.ReadAllText(settingsFilePath);
        if (jason.Length != 0)
        {
            SettingsData loadedSettingsData = JsonUtility.FromJson<SettingsData>(jason);
            MouseSensitivityManager.mouseSensitivityValue = loadedSettingsData.mouseSensitivityValue;
            VolumeManager.volumeValue = loadedSettingsData.volumeValue;
            VolumeManager.volumeSliderValue = loadedSettingsData.volumeSliderValue;
            VolumeManager.volumeTextValue = loadedSettingsData.volumeTextValue;
            ResolutionManager.resolutionIndex = loadedSettingsData.resolutionIndex;
            QualityManager.qualityIndex = loadedSettingsData.qualityIndex;
            FullScreenManager.isFullScreen = loadedSettingsData.fullScreen;
        }
    }

    public void SaveSettingsData()
    {
        SettingsData settingsData = new SettingsData();
        settingsData.mouseSensitivityValue = MouseSensitivityManager.mouseSensitivityValue;
        settingsData.volumeValue = VolumeManager.volumeValue;
        settingsData.volumeSliderValue = VolumeManager.volumeValue;
        settingsData.volumeTextValue = VolumeManager.volumeTextValue;
        settingsData.resolutionIndex = ResolutionManager.resolutionIndex;
        settingsData.qualityIndex = QualityManager.qualityIndex;
        settingsData.fullScreen = FullScreenManager.isFullScreen;

        string jason = JsonUtility.ToJson(settingsData);
        Debug.Log(jason);

        File.WriteAllText(settingsFilePath, jason);
    }

    private bool IsSettingsFileExists()
    {
        return File.Exists(settingsFilePath);
    }

    private bool IsSaveDirectoryExist()
    {
        return Directory.Exists(directoryPath);
    }
}
