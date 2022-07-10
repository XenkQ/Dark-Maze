using UnityEngine;

public class DeathMenuManager : MonoBehaviour, ICanExitGame, ICanRestartLvl
{
    [SerializeField] private GameObject deathMenuContent;
    private FleshLight fleshLight;

    private void Awake()
    {
        fleshLight = GameObject.FindGameObjectWithTag("FleshLight").GetComponent<FleshLight>();
    }

    public void ActiveDeathMenuContent()
    {
        if(deathMenuContent.active == false)
        {
            ESCMenu.BlockFunctionality();
            GameTimeManager.PauseGame();
            fleshLight.PauseFleshLightActions();
            CursorManager.UnlockCursor();
            deathMenuContent.SetActive(true);
        }
    }

    public void Exit()
    {
        ApplicationManager.ExitApplication();
    }

    public void RestartGame()
    {
        GameSceneManager.RestartCurrentScene();
    }
}
