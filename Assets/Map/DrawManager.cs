using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Line _linePrefab;
    [SerializeField][Range(0.01f, 0.9f)] private float _lineZOffset = 0.01f;
    [SerializeField] private LayerMask mapLayerMask;
    [SerializeField] private Transform _map;
    public const float RESOLUTION = 0.01f;
    private Line _currentLine;

    void Update()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5f, mapLayerMask))
        {
            if (Input.GetMouseButtonDown(0))
            {
                _currentLine = Instantiate(_linePrefab, _map.transform.position, this.transform.rotation, this.transform);
                ChangeTransformZOffset(_currentLine.transform, _lineZOffset);
            }
            else if (Input.GetMouseButton(0))
            {
                //TODO: make if pointer exit from map stop working
                if (Physics.Raycast(ray, out hit, 5f, mapLayerMask))
                {
                    _currentLine.SetPosition(_map.transform.InverseTransformPoint(hit.point) * _map.localScale.x);
                }
            }
        }
    }

    private void ChangeTransformZOffset(Transform target,float zOffset)
    {
        target.transform.localPosition = new Vector3(
            target.transform.localPosition.x,
            target.transform.localPosition.y + zOffset,
            target.transform.localPosition.z
        );
    }
}
