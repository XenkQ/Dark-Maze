using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AmbientSoundsPlayer : MonoBehaviour
{
    [SerializeField] private float playSoundDelayMin = 30;
    [SerializeField] private float playSoundDelayMax = 50;
    [SerializeField] private AudioClip[] ambientSounds;
    private AudioSource audioSource;
    private float spawningDelay = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        spawningDelay = playSoundDelayMin;
    }

    private void Update()
    {
        PlayRandomAmbientSoundAfterRandomDelay();
    }

    private void PlayRandomAmbientSoundAfterRandomDelay()
    {
        if (spawningDelay < 0)
        {
            RandomDelay(playSoundDelayMin, playSoundDelayMax);
            PlayRandomAmbientSoundProcess();
        }
        else
        {
            spawningDelay -= Time.deltaTime;
        }
    }

    private void PlayRandomAmbientSoundProcess()
    {
        if (!audioSource.isPlaying)
        {
            PlayAudio(GetRandomSound());
        }
    }

    private void PlayAudio(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    private AudioClip GetRandomSound()
    {
        return ambientSounds[Random.Range(0, ambientSounds.Length)];
    }

    private void RandomDelay(float min, float max)
    {
        spawningDelay = Random.Range(min, max + 1);
    }
}
