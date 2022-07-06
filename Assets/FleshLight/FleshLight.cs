using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleshLight : MonoBehaviour
{
    private Light lightComponent;
    private bool isLightEnabled = true;

    private void Awake()
    {
        lightComponent = GetComponent<Light>();
    }

    private void Update()
    {
        OnMouseLeftClickActions();
    }

    private void OnMouseLeftClickActions()
    {
        if(Input.GetMouseButtonDown(0) && isLightEnabled == false)
        {
            Debug.Log("Click " + isLightEnabled);
            EnableLight();
        }
        else if(Input.GetMouseButtonDown(0) && isLightEnabled == true)
        {
            Debug.Log("Click " + isLightEnabled);
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
