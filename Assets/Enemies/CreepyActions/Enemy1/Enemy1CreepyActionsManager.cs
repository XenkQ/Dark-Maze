using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1CreepyActionsManager : MonoBehaviour
{
    private enum CreepyActionType
    {
        JumpBehindWall
    }

    [SerializeField] private CreepyActionType actionType;

    [Header("Actions")]
    [SerializeField] private GameObject jumpBehindWallAction;

    public void PlayCreepyActionRelatedToActionType()
    {
        switch(actionType)
        {
            case CreepyActionType.JumpBehindWall:
                jumpBehindWallAction.SetActive(true);
                break;
        }
    }
}
