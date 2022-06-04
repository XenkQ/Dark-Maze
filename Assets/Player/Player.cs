using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    public Camera PlayerCamera { get { return playerCamera; } }

    public void MakePlayerUnkillable()
    {
        transform.tag = "UnkillablePlayer";
    }

    public void MakePlayerKillable()
    {
        transform.tag = "Player";
    }
}
