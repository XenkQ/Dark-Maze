using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesInSceneMenager : MonoBehaviour
{
    [SerializeField] private GameObject[] allEnemiesFromScene;

    public void DisableAllEnemies()
    {
        foreach(GameObject enemy in allEnemiesFromScene)
        {
            enemy.SetActive(false);
        }
    }
}
