using UnityEngine;

public class FleshLight : MonoBehaviour
{
    private Light lightComponent;
    private bool isLightEnabled = true;
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
        if(!map.IsVisible()) //NotWorking bo po wy³¹czeniu mapy latarka nie dzia³a
        {
            canUse = true;
        }
    }

    private void OnMouseLeftClickActions()
    {
        if (Input.GetMouseButtonDown(0) && isLightEnabled == false)
        {
            EnableLight();
        }
        else if (Input.GetMouseButtonDown(0) && isLightEnabled == true)
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
