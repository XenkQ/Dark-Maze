using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTriggers : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.transform.name} enter");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other.transform.name} exit");
    }
}
