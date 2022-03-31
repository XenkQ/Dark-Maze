using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject map;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            map.SetActive(!map.active);
        }
    }
}