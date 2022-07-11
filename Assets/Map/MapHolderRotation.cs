using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHolderRotation : MonoBehaviour
{
    [SerializeField] private Transform parent;
    private Vector3 pos, fw, up;

    private void Start()
    {
        pos = parent.transform.InverseTransformPoint(transform.position);
        fw = parent.transform.InverseTransformDirection(transform.forward);
        up = parent.transform.InverseTransformDirection(transform.up);
    }

    void Update()
    {
        Vector3 newpos = parent.transform.TransformPoint(pos);
        Vector3 newfw = parent.transform.TransformDirection(fw);
        Vector3 newup = parent.transform.TransformDirection(up);
        Quaternion newrot = Quaternion.LookRotation(newfw, newup);
        transform.position = newpos;
        transform.rotation = newrot;
    }
}
