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
        }
    }
}