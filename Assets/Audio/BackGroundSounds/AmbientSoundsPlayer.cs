using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AmbientSoundsPlayer : MonoBehaviour
{
    [SerializeField] private float playSoundDelayMin = 30;
    [SerializeField] private float playSoundDelayMax = 50;
    [SerializeField] private AudioClip[] audioClips;
    private AudioSource audioSource;
    private float spawningDelay = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spawningDelay = playSoundDelayMin;
    }

    private void Update()
    {
        PlayAmbientSoundsProcess();
    }

    private void PlayAmbientSoundsProcess()
    {
        if (spawningDelay < 0)
        {
            if (!audioSource.isPlaying)
            {
                PlayAudio();
                RandomDelay(playSoundDelayMin, playSoundDelayMax);
            }
        }
        else
        {
            spawningDelay -= Time.deltaTime;
        }
    }

    private void PlayAudio()
    {
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
    }

    private void RandomDelay(float min, float max)
    {
        spawningDelay = Random.Range(min, max + 1);
    }
}
