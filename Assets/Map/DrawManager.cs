using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Line _linePrefab;
    
    [SerializeField] private Vector3 _linesCentralPointLocalCoordinates;
    //? new Vector3(-0.0309999995f,-1.22000003f,-1.97599995f);
    public const float RESOLUTION = 0.01f;
    private Line _currentLine;
    [SerializeField] private LayerMask mapLayerMask;

    void Update()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray,out hit, 5f, mapLayerMask))
            {
                _currentLine = Instantiate(_linePrefab, hit.point, Quaternion.identity, this.transform);
                _currentLine.transform.localPosition = new Vector3(
                    _linesCentralPointLocalCoordinates.x,
                    _linesCentralPointLocalCoordinates.y,
                    _linesCentralPointLocalCoordinates.z
                );

                //_currentLine.SetPositionOnZero();
            }
        }

        //TODO: make if pointer exit from map stop working
        if(Input.GetMouseButton(0))
        {
            if(Physics.Raycast(ray,out hit, 5f, mapLayerMask))
            {
                _currentLine.SetPosition(hit.point);
            }
        }
    }
}
