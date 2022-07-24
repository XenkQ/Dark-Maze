using UnityEngine;

public class FleshLight : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip switchOnSound;
    [SerializeField] private AudioClip switchOffSound;
    private Light lightComponent;
    private bool isLightEnabled = false;
    private bool canUse = true;
    private Map map;

    private void Awake()
    {
        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        lightComponent = GetComponent<Light>();
    }

    private void Update()
    {
        if (canUse) { OnMouseLeftClickActions(); }
    }

    public void PauseFleshLightActions()
    {
        canUse = false;
    }

    public void UnpauseFleshLightActions()
    {
        if(!map.IsVisible())
        {
            canUse = true;
        }
    }

    private void OnMouseLeftClickActions()
    {
        if (Input.GetMouseButtonDown(0) && isLightEnabled == false)
        {
            PlaySwitchOnSound();
            EnableLight();
        }
        else if (Input.GetMouseButtonDown(0) && isLightEnabled == true)
        {
            PlaySwitchOffSound();
            DisableLight();
        }
    }

    private void DisableLight()
    {
        lightComponent.enabled = false;
        isLightEnabled = false;
    }

    private void EnableLight()
    {
        lightComponent.enabled = true;
        isLightEnabled = true;
    }

    private void PlaySwitchOnSound()
    {
        audioSource.PlayOneShot(switchOnSound);
    }

    private void PlaySwitchOffSound()
    {
        audioSource.PlayOneShot(switchOffSound);
    }
}
