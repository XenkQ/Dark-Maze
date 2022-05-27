using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolLocker : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;
    private Player player;
    public bool IsOpen { get { return isOpen; } }

    void Awake()
    {
        animator = GetComponent<Animator>();
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

    public void PlayOpenAnimation()
    {
        animator.SetTrigger("OpenLocker");
        isOpen = true;
    }

    public void PlayCloseAnimation()
    {
        animator.SetTrigger("CloseLocker");
        isOpen = false;
    }
}
