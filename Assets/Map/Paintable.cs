using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{
    [SerializeField] private GameObject Brush;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float _brushSize;
    [SerializeField] private LayerMask mapLayerMask;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 3f,mapLayerMask))
            {
                var paintedObject = Instantiate(Brush, hit.point, transform.rotation, transform);
                paintedObject.transform.localPosition = new Vector3(
                    paintedObject.transform.localPosition.x,
                    paintedObject.transform.localPosition.y + 0.1f,
                    paintedObject.transform.localPosition.z
                );
                paintedObject.transform.localScale = Vector3.one * _brushSize;
            }
        }
    }
}
