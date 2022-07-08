using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleshLight : MonoBehaviour
{
    private Light lightComponent;
    private bool isLightEnabled = true;
    [SerializeField] private float maxDistanceToShrink = 1f;

    private void Awake()
    {
        lightComponent = GetComponent<Light>();
    }

    private void Update()
    {
        OnMouseLeftClickActions();

        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, maxDistanceToShrink))
        {
            Debug.Log("Hit");
            //lightComponent.spotAngle -= 20 * Time.deltaTime;
            //lightComponent.innerSpotAngle -= 20 * Time.deltaTime;
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxDistanceToShrink, Color.blue);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxDistanceToShrink, Color.gray);
        }
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
