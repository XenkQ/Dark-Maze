using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AllEnemiesInSceneManager allEnemiesInSceneManager;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private GameObject playerModel;
    public Camera PlayerCamera { get { return playerCamera; } }

    private void FixedUpdate()
    {
        DisableAllEnemiesIfPlayerModelIsDisabled();
    }

    private void DisableAllEnemiesIfPlayerModelIsDisabled()
    {
        if(playerModel.active == false)
        {
            allEnemiesInSceneManager.DisableAllEnemies();
        }
    }

    public void MakePlayerUnkillable()
    {
        transform.tag = "UnkillablePlayer";
    }

    public void MakePlayerKillable()
    {
        transform.tag = "Player";
    }
}
