using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [Header("Ray")]
    [SerializeField] private float maxInteractionRange = 3f;

    [Header("Objects")]
    [SerializeField] private Player player;

    [Header("Other Scripts")]
    [SerializeField] CursorManager cursorManager;
    [SerializeField] PlayerCamera playerCamera;

    private void Update()
    {
        InteractWithVisibleObject();
    }

    private void InteractWithVisibleObject()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitinfo, maxInteractionRange))
        {
            switch (hitinfo.transform.tag)
            {
                case "SchoolLockerDoor":
                    hitinfo.transform.parent.GetComponent<SchoolLockerInteractions>().InteractWithSchoolLockerDoor();
                    break;

                case "Note":
                    hitinfo.transform.GetComponent<NoteInteractions>().InteractWithNote();
                    break;
            }

            Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxInteractionRange, Color.red);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxInteractionRange, Color.green);
        }
    }
}
