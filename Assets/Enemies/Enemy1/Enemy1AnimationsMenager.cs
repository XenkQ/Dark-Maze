using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy1AnimationsMenager : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartSearchingAnimation()
    {
        animator.SetBool("isSearching", true);
    }

    public void StopSearchingAnimation()
    {
        animator.SetBool("isSearching", false);
    }
}
