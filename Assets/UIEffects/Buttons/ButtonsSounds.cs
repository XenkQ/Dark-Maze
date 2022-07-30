using UnityEngine;

public class ButtonsSounds : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonHoverSound;
    [SerializeField] private AudioClip buttonClickSound;

    public void OnButtonHoverSound()
    {
        audioSource.PlayOneShot(buttonHoverSound);
    }

    public void OnButtonClickSound()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }
}
