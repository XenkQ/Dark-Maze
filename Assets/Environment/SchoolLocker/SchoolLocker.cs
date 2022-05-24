using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolLocker : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;
    public bool IsOpen { get { return isOpen; } }

    void Start()
    {
        animator = GetComponent<Animator>();
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

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && !isOpen)
        {
            other.transform.tag = "UnkillablePlayer";
        }
        else if(other.tag == "UnkillablePlayer" && isOpen)
        {
            other.transform.tag = "Player";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "UnkillablePlayer" && isOpen)
        {
            other.transform.tag = "Player";
        }
    }
}
