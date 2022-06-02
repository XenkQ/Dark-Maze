using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void MakePlayerUnkillable()
    {
        transform.tag = "UnkillablePlayer";
    }

    public void MakePlayerKillable()
    {
        transform.tag = "Player";
    }
}
