using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AmbientSoundsPlayer : MonoBehaviour
{
    [SerializeField] AudioClip ambientSound;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PrepareAudioSorceForPlayingAmbientSound();
        audioSource.Play();
    }

    private void PrepareAudioSorceForPlayingAmbientSound()
    {
        audioSource.clip = ambientSound;
        audioSource.time = GetRandomClipSecond(ambientSound);
    }

    private float GetRandomClipSecond(AudioClip audioClip)
    {
        return Random.Range(0, audioClip.length);
    }
}
