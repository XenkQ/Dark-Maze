using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolLockerInteractions : MonoBehaviour
{
    [SerializeField] private SchoolLocker schoolLocker;
    [SerializeField] private SchoolLockerAnimationsManager schoolLockerAnimationsManager;

    public void OpenSchoolLocker()
    {
        schoolLockerAnimationsManager.PlayOpenAnimation();
        schoolLocker.isOpen = true;
    }

    public void CloseSchoolLocker()
    {
        schoolLockerAnimationsManager.PlayCloseAnimation();
        schoolLocker.isOpen = false;
    }

    public void InteractWithSchoolLockerDoor()
    {
        OpenCloseSchoolLockerAfterPressingE();
    }

    private void OpenCloseSchoolLockerAfterPressingE()
    {
        if (Input.GetKeyDown(KeyCode.E) && !schoolLocker.isOpen)
        {
            OpenSchoolLocker();
        }
        else if (Input.GetKeyDown(KeyCode.E) && schoolLocker.isOpen)
        {
            CloseSchoolLocker();
        }
    }
}
