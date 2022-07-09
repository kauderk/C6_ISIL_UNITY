using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMouseUtils : MonoBehaviour
{
    public CursorLockMode _wantedMode;


    private void OnEnable() => menso();
    //private void Awake() => menso();

    private void menso()
    {
        _wantedMode = CursorLockMode.Locked;
        SetCursorState();
    }

    private void OnDisable()
    {
        _wantedMode = CursorLockMode.None;
        SetCursorState();
    }

    // Apply requested cursor state
    private void SetCursorState()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = _wantedMode = CursorLockMode.None;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _wantedMode = CursorLockMode.Locked;
        }

        // Apply cursor state
        Cursor.lockState = _wantedMode;
        // Hide cursor when locking
        Cursor.visible = (CursorLockMode.Locked != _wantedMode);
    }
}
