using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AmbientSoundsPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private float playSoundDelayMin = 30;
    [SerializeField] private float playSoundDelayMax = 50;
    private float spawningDelay = 0;
    [SerializeField] private AudioClip[] audioClips;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spawningDelay = playSoundDelayMin;
    }

    private void Update()
    {
        if (spawningDelay < 0)
        {
            if (!audioSource.isPlaying)
            {
                PlayAudio();
                RandomDelay(playSoundDelayMin,playSoundDelayMax);
            }
        }
        else
        {
            spawningDelay -= Time.deltaTime;
        }
    }

    private void RandomDelay(float min, float max)
    {
        spawningDelay = Random.Range(min, max + 1);
    }

    private void PlayAudio()
    {
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
    }
}
