using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Saving : MonoBehaviour
{
    private string _settingsFilePath;
    SettingsMenu settingsMenu = new SettingsMenu();

    private void Awake()
    {
        _settingsFilePath = Application.dataPath + "/settingsFile.json";
        SetSettingsData();
        DontDestroyOnLoad(this.gameObject);
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

    public void SaveSettingsData(int mouseSensitivityValue,float volumeValue, float volumeSliderValue, float volumeTextValue, int resolutionIndex, int qualityIndex, bool fullScreen)
    {
        SettingsData settingsData = new SettingsData();
        settingsData.mouseSensitivityValue = mouseSensitivityValue;
        settingsData.volumeValue = volumeValue;
        settingsData.volumeSliderValue = volumeSliderValue;
        settingsData.volumeTextValue = volumeTextValue;
        settingsData.resolutionIndex = resolutionIndex;
        settingsData.qualityIndex = qualityIndex;
        settingsData.fullScreen = fullScreen;

        string jason = JsonUtility.ToJson(settingsData);
        Debug.Log(jason);

        File.WriteAllText(_settingsFilePath, jason);
    }

    public void SetSettingsData()
    {
        if(isSettingsFileExists())
        {
            string jason = File.ReadAllText(_settingsFilePath);
            SettingsData loadedSettingsData = JsonUtility.FromJson<SettingsData>(jason);
            SettingsMenu.mouseSensitivityValue = loadedSettingsData.mouseSensitivityValue;
            SettingsMenu.volumeValue = loadedSettingsData.volumeValue;
            SettingsMenu.volumeSliderValue = loadedSettingsData.volumeSliderValue;
            SettingsMenu.volumeTextValue = loadedSettingsData.volumeTextValue;
            SettingsMenu.resolutionIndex = loadedSettingsData.resolutionIndex;
            SettingsMenu.qualityIndex = loadedSettingsData.qualityIndex;
            SettingsMenu.isFullScreen = loadedSettingsData.fullScreen;
        }
    }

    public bool isSettingsFileExists()
    {
        if(File.Exists(_settingsFilePath))
        {
            return true;
        }    
        else
        {
            return false;
        }    
    }
}
