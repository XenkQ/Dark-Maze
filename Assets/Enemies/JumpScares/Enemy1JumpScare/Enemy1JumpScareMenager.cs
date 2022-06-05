using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class Enemy1JumpScareMenager : MonoBehaviour
{
    [Header("JumpScare Properties")]
    [SerializeField] private float timeHowLongPlayerMustSeeOpponentToActivateJumpScare = 3f;
    [SerializeField] private GameObject jumpScareObject;
    [SerializeField] private GameObject[] objectsToDisableWhenJumpScare;
    private bool isJumpScareActivating = false;

    [Header("Other Scripts")]
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        JumpScareProcess();
    }

    private void JumpScareProcess()
    {
        Debug.Log("JumpScareProcessStart" + (enemy.IsVisibleByCamera() && isJumpScareActivating == false));
        if (enemy.IsVisibleByCamera() && isJumpScareActivating == false)
        {
            StartCoroutine(WaitForJumpScare());
        }
    }

    private IEnumerator WaitForJumpScare()
    {
        isJumpScareActivating = true;
        Debug.Log("ZARAZ JUMP SCARE");
        yield return new WaitForSeconds(timeHowLongPlayerMustSeeOpponentToActivateJumpScare);
        ActivateJumpScareIfEnemyIsVisibleByCamera();
        isJumpScareActivating = false;
    }

    private void ActivateJumpScareIfEnemyIsVisibleByCamera()
    {
        if (enemy.IsVisibleByCamera())
        {
            JumpScareActivationProcess();
        }
    }

    private void JumpScareActivationProcess()
    {
        DisableObjectToDisable();
        ActivateJumpScare();
    }

    private void DisableObjectToDisable()
    {
        foreach(GameObject objectToDisable in objectsToDisableWhenJumpScare)
        {
            objectToDisable.SetActive(false);
        }
    }

    private void ActivateJumpScare()
    {
        jumpScareObject.SetActive(true);
    }
}
