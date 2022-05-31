using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneMenager
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
