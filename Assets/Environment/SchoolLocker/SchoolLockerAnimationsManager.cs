using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SchoolLockerAnimationsManager : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayOpenAnimation()
    {
        animator.SetTrigger("OpenLocker");
    }

    public void PlayCloseAnimation()
    {
        animator.SetTrigger("CloseLocker");
    }
}
