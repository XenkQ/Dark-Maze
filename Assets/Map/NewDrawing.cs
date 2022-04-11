using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDrawing : MonoBehaviour
{
    [SerializeField] private NewLine _linePrefab;
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private Transform _mapTransform;
    [SerializeField] private float _lineZOffset = 0.01f;

    [SerializeField] private GameObject _emptyTestObject;

    private NewLine _newLine;

    private bool firstClick = true;


    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3f, _mask))
        {
            if (Input.GetMouseButtonDown(0) && firstClick)
            {
                _newLine = Instantiate(_linePrefab, new Vector3(hit.point.x, hit.point.y, hit.point.z + _lineZOffset),
                _mapTransform.rotation, this.transform).GetComponent<NewLine>();
                _newLine.AddPosition(hit.point);
                firstClick = false;
            }
            else if(Input.GetMouseButtonDown(0) && !firstClick)
            {
                Transform empty = Instantiate(_emptyTestObject, new Vector3(hit.point.x, hit.point.y, hit.point.z + _lineZOffset)
                ,_mapTransform.rotation, this.transform).transform;
                _newLine.AddPosition(hit.point);
            }
            // else if (Input.GetMouseButton(0))
            // {
            //     _newLine.AddPosition(hit.point);
            // }
            
        }
    }
}
