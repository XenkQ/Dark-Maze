using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemySoundsPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] enemyLaughingSounds;
    private AudioClip lastLaughSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        PlayRandomLaughSound();
    }

    private void PlayRandomLaughSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(RandomStepSound());
        }
    }

    private AudioClip RandomStepSound()
    {
        AudioClip laughSound;
        do
        {
            laughSound = enemyLaughingSounds[Random.Range(0, enemyLaughingSounds.Length)];
        }
        while (lastLaughSound == laughSound);
        lastLaughSound = laughSound;
        return laughSound;
    }
}
