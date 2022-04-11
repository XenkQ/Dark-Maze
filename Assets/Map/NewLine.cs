using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLine : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _resolution;

    public void AddPosition(Vector3 pos)
    {
        Debug.Log(_lineRenderer.positionCount);
        if(_lineRenderer.positionCount<1)
        {
            _lineRenderer.positionCount++;
            _lineRenderer.SetPosition(0, new Vector2(pos.x,pos.y));
        }
        else if(CanPlace(pos))
        {
            _lineRenderer.positionCount++;
            _lineRenderer.SetPosition(_lineRenderer.positionCount-1, new Vector2(pos.x,pos.y));
        }
    }

    public bool CanPlace(Vector3 pos)
    {
        return Vector3.Distance(_lineRenderer.GetPosition(_lineRenderer.positionCount-1), pos) > _resolution;
    }
}
