using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    public void PauseGame()
    {
        if(Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
    }

    public void UnpauseGame()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
