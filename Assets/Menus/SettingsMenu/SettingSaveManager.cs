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
        public int resolutionIndex;
        public int qualityIndex;
        public bool isFullScreen;
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
            ResolutionManager.resolutionIndex = loadedSettingsData.resolutionIndex;
            QualityManager.qualityIndex = loadedSettingsData.qualityIndex;
            FullScreenManager.isFullScreen = loadedSettingsData.isFullScreen;
        }
    }

    public void SaveSettingsData()
    {
        SettingsData settingsData = new SettingsData();
        settingsData.mouseSensitivityValue = MouseSensitivityManager.mouseSensitivityValue;
        settingsData.volumeValue = VolumeManager.volumeValue;
        settingsData.volumeSliderValue = VolumeManager.volumeSliderValue;
        settingsData.resolutionIndex = ResolutionManager.resolutionIndex;
        settingsData.qualityIndex = QualityManager.qualityIndex;
        settingsData.isFullScreen = FullScreenManager.isFullScreen;
        WriteSettingsToJasonFile(settingsData);
    }

    private void WriteSettingsToJasonFile(SettingsData settingsData)
    {
        string jason = JsonUtility.ToJson(settingsData);
        Debug.Log(jason);
        File.WriteAllText(settingsFilePath, jason);
    }

    //public void SaveSettingsValue(float value , SettingsType settingsType)
    //{
    //    SettingsData settingsData = new SettingsData();
    //    switch (settingsType)
    //    {
    //        case SettingsType.MouseSensitivityValue:
    //            settingsData.mouseSensitivityValue = MouseSensitivityManager.mouseSensitivityValue;
    //            WriteSettingsToJasonFile(settingsData);
    //            break;

    //        case SettingsType.VolumeValue:
    //            settingsData.volumeValue = VolumeManager.volumeValue;
    //            WriteSettingsToJasonFile(settingsData);
    //            break;

    //        case SettingsType.VolumeSliderValue:
    //            settingsData.volumeSliderValue = VolumeManager.volumeSliderValue;
    //            WriteSettingsToJasonFile(settingsData);
    //            break;

    //        case SettingsType.ResolutionIndex:
    //            settingsData.resolutionIndex = ResolutionManager.resolutionIndex;
    //            WriteSettingsToJasonFile(settingsData);
    //            break;

    //        case SettingsType.QualityIndex:
    //            settingsData.qualityIndex = QualityManager.qualityIndex;
    //            WriteSettingsToJasonFile(settingsData);
    //            break;

    //        case SettingsType.IsFullScreen:
    //            settingsData.isFullScreen = FullScreenManager.isFullScreen;
    //            WriteSettingsToJasonFile(settingsData);
    //            break;
    //    }
    //}

    private bool IsSettingsFileExists()
    {
        return File.Exists(settingsFilePath);
    }

    private bool IsSaveDirectoryExist()
    {
        return Directory.Exists(directoryPath);
    }
}
