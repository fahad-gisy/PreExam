using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCursor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnTriggerExit(Collider other)
    {
        Cursor.visible = false;
    }
}
