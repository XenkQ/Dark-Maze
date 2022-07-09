using UnityEngine;

public class WinMenu : MonoBehaviour, ICanExitGame, ICanRestartLvl
{
    [SerializeField] private GameObject winMenuContent;
    private FleshLight fleshLight;

    private void Awake()
    {
        fleshLight = GameObject.FindGameObjectWithTag("FleshLight").GetComponent<FleshLight>();
    }

    public void ActiveWinMenuContent()
    {
        if(winMenuContent.active == false)
        {
            GameTimeManager.PauseGame();
            fleshLight.PauseFleshLightActions();
            CursorManager.UnlockCursor();
            winMenuContent.SetActive(true);
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
