using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleshLight : MonoBehaviour
{
    private Light lightComponent;
    private bool isLightEnabled = true;
    private bool canUse = true;
    [SerializeField] private float maxDistanceToShrink = 1f;

    private void Awake()
    {
        lightComponent = GetComponent<Light>();
    }

    private void Update()
    {
        if(canUse){ OnMouseLeftClickActions(); }
    }

    public void PauseFleshLightActions()
    {
        canUse = false;
    }

    public void UnpauseFleshLightActions()
    {
        canUse = true;
    }

    private void OnMouseLeftClickActions()
    {
        if(Input.GetMouseButtonDown(0) && isLightEnabled == false)
        {
            EnableLight();
        }
        else if(Input.GetMouseButtonDown(0) && isLightEnabled == true)
        {
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
}
