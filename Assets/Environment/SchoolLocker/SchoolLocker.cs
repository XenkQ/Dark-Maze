using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolLocker : MonoBehaviour
{
    public bool isOpen = false;
    private Player player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerStay(Collider other)
    {
        LockerTriggersRelatedToPlayerActions(other);
    }

    private void OnTriggerExit(Collider other)
    {
        LockerTriggersRelatedToPlayerActions(other);
    }

    private void LockerTriggersRelatedToPlayerActions(Collider other)
    {
        if (other.tag == "Player" && !isOpen)
        {
            player.MakePlayerUnkillable();
        }
        else if(other.tag == "UnkillablePlayer" && isOpen)
        {
            player.MakePlayerKillable();
        }
        else if (other.tag == "UnkillablePlayer" && isOpen)
        {
            player.MakePlayerKillable();
        }
    }
}
