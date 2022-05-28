using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameTimeMenager gameTimeMenager;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            ChangeMapMode();
        }
    }

    private void ChangeMapMode()
    {
        SwitchMapVisibility();

        if (IsMapVisible())
        {
            ActiveMapDrawMode();
        }
        else
        {
            DisableMapDrawMode();
        }
    }
    private void SwitchMapVisibility()
    {
        meshRenderer.enabled = !meshRenderer.enabled;
    }

    public bool IsMapVisible()
    {
        return meshRenderer.enabled;
    }

    private void ActiveMapDrawMode()
    {
        gameTimeMenager.PauseGame();
        Cursor.lockState = CursorLockMode.None;
    }

    private void DisableMapDrawMode()
    {
        gameTimeMenager.UnpauseGame();
        Cursor.lockState = CursorLockMode.Locked;
    }
}