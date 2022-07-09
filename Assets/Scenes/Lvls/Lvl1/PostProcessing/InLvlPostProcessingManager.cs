using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Volume))]
public class InLvlPostProcessingManager : MonoBehaviour
{
    [Header("Volume Components")]
    private VolumeProfile volumeProfile;
    private Volume volume;

    [Header("Effects")]
    private DepthOfField depthOfField;

    private void Awake()
    {
        volume = GetComponent<Volume>();
        volumeProfile = volume.sharedProfile;
    }

    public void ActiveDepthOfFieldEffect(bool value)
    {
        if(volumeProfile.TryGet<DepthOfField>(out depthOfField))
        {
            depthOfField.active = value;
        }
    }
}
