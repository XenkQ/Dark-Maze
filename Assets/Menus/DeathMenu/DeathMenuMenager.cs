using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenuMenager : MonoBehaviour
{
    private void OnEnable()
    {
        CursorMenager.UnlockCursor();
    }

    public void OnTryAgainButtonClick()
    {
        Debug.Log("Click");
        GameSceneMenager.RestartCurrentScene();
    }
}
