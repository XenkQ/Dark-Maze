using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy1AnimationsMenager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void StartSearchingAnimation()
    {
        animator.SetBool("isSearching", true);
    }

    public void StopSearchingAnimation()
    {
        animator.SetBool("isSearching", false);
    }
}
