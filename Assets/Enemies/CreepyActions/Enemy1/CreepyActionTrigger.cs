using UnityEngine;

public class CreepyActionTrigger : MonoBehaviour
{
    [SerializeField] private Enemy1CreepyActionsManager enemy1CreepyActionsManager;
    private bool playerTriggeredOnce = false;
    public bool PlayerTriggeredOnce { get { return playerTriggeredOnce; } }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            OnPlayerTriggerPlayCreepyAction();
        }
    }

    private void OnPlayerTriggerPlayCreepyAction()
    {
        if (playerTriggeredOnce == false)
        {
            enemy1CreepyActionsManager.PlayCreepyActionRelatedToActionType();
            playerTriggeredOnce = true;
        }
    }
}
