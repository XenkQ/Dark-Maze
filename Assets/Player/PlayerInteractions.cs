using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [Header("Ray")]
    [SerializeField] private float maxInteractionRange = 3f;

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
                    cursorManager.EnableZoomInteractionCursor();
                    hitinfo.transform.GetComponent<NoteInteractions>().InteractWithNote();
                    break;

                default:
                    cursorManager.DisableZoomInteractionCursor();
                    playerCamera.ReturnToDeafultZoom();
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
