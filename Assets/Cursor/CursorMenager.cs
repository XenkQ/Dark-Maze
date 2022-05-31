using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMenager
{
    public static void UnlockCursor()
    {
        if(Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public static void LockCursor()
    {
        if(Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
