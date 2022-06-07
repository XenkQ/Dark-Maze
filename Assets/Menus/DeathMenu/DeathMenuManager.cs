using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenuManager : MonoBehaviour
{
    private void OnEnable()
    {
        CursorManager.UnlockCursor();
    }

    public void OnTryAgainButtonClick()
    {
        Debug.Log("Click");
        GameSceneManager.RestartCurrentScene();
    }
}
