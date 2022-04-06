using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] Transform sphere1;
    [SerializeField] Transform sphere2;
    private void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0,sphere1.position);
        lineRenderer.SetPosition(1,sphere2.position);
    }
}
