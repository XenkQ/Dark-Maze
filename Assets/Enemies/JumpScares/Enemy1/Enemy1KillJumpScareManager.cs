using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class Enemy1KillJumpScareManager : MonoBehaviour
{
    [Header("JumpScare Properties")]
    [SerializeField] private float minDistanceToInstantJumpScare = 3f;
    [SerializeField] private float timeHowLongPlayerMustSeeOpponentToActivateJumpScare = 3f;
    [SerializeField] private GameObject jumpScareObject;
    [SerializeField] private GameObject[] objectsToDisableWhenJumpScare;
    private bool isJumpScareActivating = false;

    [Header("Other Scripts")]
    private Enemy enemy;
    private Player player;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        JumpScareProcess();
    }

    private void JumpScareProcess()
    {
        if (enemy.IsVisibleByCamera() && isJumpScareActivating == false)
        {
            StartCoroutine(WaitForJumpScare());
        }

        JumpScareIfPlayerTooClose();
    }

    private IEnumerator WaitForJumpScare()
    {
        isJumpScareActivating = true;
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

    private void JumpScareIfPlayerTooClose()
    {
        Vector3 playerPos = player.transform.position;
        if (Vector3.Distance(transform.position, playerPos) <= minDistanceToInstantJumpScare && !enemy.IsTargetBehindObstacle())
        {
            JumpScareActivationProcess();
            StopAllCoroutines();
        }
    }

    private void JumpScareActivationProcess()
    {
        DisableObjectsToDisable();
        ActivateJumpScare();
    }

    private void DisableObjectsToDisable()
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
