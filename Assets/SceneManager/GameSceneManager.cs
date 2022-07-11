using UnityEngine.SceneManagement;

public class GameSceneManager
{
    public static void StartFirstLvlScene()
    {
        SceneManager.LoadScene(1);
    }

    public static void RestartCurrentScene()
    {
        SceneManager.LoadScene(GetCurrentSceneBuildIndex());
    }

    public static int GetCurrentSceneBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
