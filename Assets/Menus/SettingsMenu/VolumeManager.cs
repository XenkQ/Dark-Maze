using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using System;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI volumeText;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;
    public static float volumeValue;
    public static float volumeSliderValue;

    private void Awake()
    {
        SetSliderValueBasedOnVolumeSliderValue();
    }

    private void Start()
    {
        ChangeVolumeSliderProperties();
    }

    private void SetSliderValueBasedOnVolumeSliderValue()
    {
        volumeSlider.value = volumeSliderValue;
    }

    private void ChangeVolumeSliderProperties()
    {
        SetVolumeValueBasedOnSliderValue();
        SetVolumeTextBasedOnVolumeValue();
    }

    private void SetVolumeValueBasedOnSliderValue()
    {
        volumeValue = Mathf.Log10(volumeSliderValue) * 20;
        audioMixer.SetFloat("volume", volumeValue);
    }

    private void SetVolumeTextBasedOnVolumeValue()
    {
        volumeText.text = ((int)(volumeSliderValue * 100)).ToString();
    }

    public void OnVolumeChange()
    {
        volumeSliderValue = volumeSlider.value;
        ChangeVolumeSliderProperties();
    }
}
