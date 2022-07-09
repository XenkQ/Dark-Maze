using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    private DeathMenuManager deathMenuManager;

    private void Awake()
    {
        deathMenuManager = GameObject.FindGameObjectWithTag("DeathMenu").GetComponent<DeathMenuManager>();
    }

    public void KillPlayerProcess()
    {
        deathMenuManager.ActiveDeathMenuContent();
    }
}
