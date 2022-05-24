using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    [SerializeField] private float maxInteractionRange = 3f;
    [SerializeField] private Camera playerCamera;
    private SchoolLocker schoolLocker;

    //UPIÊKSZYÆ
    void Update()
    {
        ObjectsVisibleForPlayer();
    }

    private void ObjectsVisibleForPlayer()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitinfo, maxInteractionRange))
        {
            if (hitinfo.transform.gameObject.tag == "SchoolLockerDoor")
            {
                schoolLocker = hitinfo.transform.parent.GetComponent<SchoolLocker>();
                if (Input.GetKeyDown(KeyCode.E) && !schoolLocker.IsOpen)
                {
                    schoolLocker.PlayOpenAnimation();
                }
                else if (Input.GetKeyDown(KeyCode.E) && schoolLocker.IsOpen)
                {
                    schoolLocker.PlayCloseAnimation();
                }
                Debug.DrawLine(ray.origin, hitinfo.point, Color.red);
                Debug.Log(hitinfo.transform.name);
            }
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxInteractionRange, Color.green);
        }
    }
}
