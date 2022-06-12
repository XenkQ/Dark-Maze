using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudioMenager : MonoBehaviour
{
    [Header("Step Sounds")]
    [SerializeField] private AudioClip[] steps;
    private AudioSource audioSource;
    private AudioClip lastStep;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StopAllSound()
    {
        audioSource.Stop();
    }

    public void PlayRandomStepSound()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(RandomStepSound());
        }
    }

    private AudioClip RandomStepSound()
    {
        AudioClip step;
        do
        {
            step = steps[Random.Range(0, steps.Length)];
        }
        while (lastStep == step);
        lastStep = step;
        return step;
    }
}
