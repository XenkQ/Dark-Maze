using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject map;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            map.SetActive(!map.active);
            //TODO: Make static;
            if(map.active)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}