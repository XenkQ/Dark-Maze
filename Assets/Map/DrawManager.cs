using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Line _linePrefab;
    [SerializeField] [Range(0.01f,0.9f)] private float _lineZOffset;
    // [SerializeField] private Vector3 _linesCentralPointLocalCoordinates;
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
                //Vector3 position = new Vector3(hit.point.x,hit.point.y,hit.point.z + _lineZOffset);
                _currentLine = Instantiate(_linePrefab, hit.point, Quaternion.identity, this.transform);
                //BUG: if player change position this is not gonna working;
                // _currentLine.transform.localPosition = new Vector3(
                //     _linesCentralPointLocalCoordinates.x,
                //     _linesCentralPointLocalCoordinates.y,
                //     _linesCentralPointLocalCoordinates.z
                // );

                // _currentLine.transform.localPosition = new Vector3(
                //     maybeWork.position.x,
                //     maybeWork.position.y,
                //     maybeWork.position.z
                // );

                //_currentLine.SetPositionOnZero();
            }
        }

        //TODO: make if pointer exit from map stop working
        if(Input.GetMouseButton(0))
        {
            if(Physics.Raycast(ray,out hit, 5f, mapLayerMask))
            {
                //Vector3 position = new Vector3(hit.point.x,hit.point.y,hit.point.z + _lineZOffset);
                _currentLine.SetPosition(hit.point);
            }
        }

        // if(Input.GetMouseButtonUp(0))
        // {
        //     _currentLine.RendererToLocalSpace();
        // }
    }
}
