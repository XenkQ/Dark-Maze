using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameTimeMenager gameTimeMenager;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
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
        meshCollider.enabled = !meshCollider.enabled;
    }

    public bool IsMapVisible()
    {
        return meshRenderer.enabled;
    }

    private void ActiveMapDrawMode()
    {
        gameTimeMenager.PauseGame();
        CursorMenager.UnlockCursor();
    }

    private void DisableMapDrawMode()
    {
        gameTimeMenager.UnpauseGame();
        CursorMenager.LockCursor();
    }
}