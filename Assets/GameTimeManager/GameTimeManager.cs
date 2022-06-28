using UnityEngine;

public static class GameTimeManager
{
    public static void PauseGame()
    {
        if(Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
    }

    public static void UnpauseGame()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
