using UnityEngine;

public class RotationLikeFakeParent : MonoBehaviour
{
    [SerializeField] private Transform fakeParent;
    private Vector3 pos, fw, up;

    private void Start()
    {
        pos = fakeParent.transform.InverseTransformPoint(transform.position);
        fw = fakeParent.transform.InverseTransformDirection(transform.forward);
        up = fakeParent.transform.InverseTransformDirection(transform.up);
    }

    void Update()
    {
        Vector3 newpos = fakeParent.transform.TransformPoint(pos);
        Vector3 newfw = fakeParent.transform.TransformDirection(fw);
        Vector3 newup = fakeParent.transform.TransformDirection(up);
        Quaternion newrot = Quaternion.LookRotation(newfw, newup);
        transform.position = newpos;
        transform.rotation = newrot;
    }
}
