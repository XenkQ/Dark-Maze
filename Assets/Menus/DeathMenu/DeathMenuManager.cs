using UnityEngine;

public class DeathMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject deathMenuContent;

    public void ActiveDeathMenuContent()
    {
        if(deathMenuContent.active == false)
        {
            deathMenuContent.SetActive(true);
            CursorManager.UnlockCursor();
        }
    }

    public void OnTryAgainButtonClick()
    {
        GameSceneManager.RestartCurrentScene();
    }

}
