using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private float maxInteractionRange = 3f;
    [SerializeField] private Camera playerCamera;
    private SchoolLocker currentSchoolLocker;

    private void Update()
    {
        ObjectsVisibleForPlayer();
    }

    private void ObjectsVisibleForPlayer()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitinfo, maxInteractionRange))
        {
            ActionsAfterPlayerSeesSchoolLockerDoors(ray, hitinfo);
            Debug.Log(hitinfo.transform.name);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxInteractionRange, Color.green);
        }
    }

    private void ActionsAfterPlayerSeesSchoolLockerDoors(Ray ray, RaycastHit hitinfo)
    {
        if (hitinfo.transform.gameObject.tag == "SchoolLockerDoor")
        {
            currentSchoolLocker = hitinfo.transform.parent.GetComponent<SchoolLocker>();
            OpenCloseSchoolLockerAfterPressingE();
            Debug.DrawLine(ray.origin, hitinfo.point, Color.red);
        }
    }

    private void OpenCloseSchoolLockerAfterPressingE()
    {
        if (Input.GetKeyDown(KeyCode.E) && !currentSchoolLocker.IsOpen)
        {
            currentSchoolLocker.PlayOpenAnimation();
        }
        else if (Input.GetKeyDown(KeyCode.E) && currentSchoolLocker.IsOpen)
        {
            currentSchoolLocker.PlayCloseAnimation();
        }
    }
}
