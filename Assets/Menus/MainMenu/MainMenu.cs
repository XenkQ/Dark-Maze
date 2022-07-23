using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour, ICanExitGame
{
    [Header("Canvases")]
    [SerializeField] private GameObject settingsMenuContent;
    [SerializeField] private GameObject mainMenu;

    public void OnButtonClick(Button button)
    {
        switch (button.name)
        {
            case "PlayButton":
                Play();
                break;

            case "ExitButton":
                Exit();
                break;
        }
    }

    private void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        ApplicationManager.ExitApplication();
    }
}
