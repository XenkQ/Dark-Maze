using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _renderer;

    // private void Start()
    // {
    //     _renderer.alignment = LineAlignment.TransformZ;
    // }

    public void SetPositionOnZero()
    {
        _renderer.positionCount++;
        
        if(_renderer.positionCount == 1)
        {
            _renderer.SetPosition(0, Vector3.zero);
        }
    }

    public void RendererToLocalSpace()
    {
        _renderer.useWorldSpace = false;
    }

    public void SetPosition(Vector3 pos)
    {
        if(!CanAppend(pos)) return;

        _renderer.positionCount++;
        
        // if(_renderer.positionCount == 1)
        // {
        //     _renderer.SetPosition(_renderer.positionCount-1, Vector3.zero);
        // }
        // else if(_renderer.positionCount > 1)
        // {
        //     _renderer.SetPosition(_renderer.positionCount-1,pos);
        // }

        _renderer.SetPosition(_renderer.positionCount-1,pos);
    }

    private bool CanAppend(Vector3 pos)
    {
        if(_renderer.positionCount == 0) {return true;}

        // if(_renderer.positionCount == 0) {
        //     _renderer.SetPosition(0,transform.localPosition);
        //     return true;
        // }
        
        return Vector3.Distance(_renderer.GetPosition(_renderer.positionCount-1),pos) > DrawManager.RESOLUTION;
    }
}
