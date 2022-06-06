using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class VolumeMenager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI volumeText;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;
    public static float volumeValue;
    public static float volumeTextValue;
    public static float volumeSliderValue;

    public void OnVolumeChange()
    {
        float value = volumeSlider.value;
        volumeSliderValue = value;
        volumeText.text = Mathf.Round(value * 100).ToString();
        volumeTextValue = int.Parse(volumeText.text);
        value = Mathf.Log10(value) * 20;
        volumeValue = value;
        SetVolume(value);
    }

    public void SetVolume(float volumeValue)
    {
        audioMixer.SetFloat("volume", volumeValue);
    }
}
