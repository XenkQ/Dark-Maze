using UnityEngine;
using System.Collections;

public class ButtonsSounds : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonHoverSound;
    [SerializeField] private AudioClip buttonClickSound;

    public void OnButtonHoverSound()
    {
        Debug.Log(audioSource.isPlaying);
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(buttonHoverSound);
        }
    }

    public void OnButtonClickSound()
    {

        audioSource.PlayOneShot(buttonClickSound);

    }
}
