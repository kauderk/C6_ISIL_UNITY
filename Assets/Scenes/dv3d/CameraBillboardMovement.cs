using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBillboardMovement : MonoBehaviour
{
    public float movemmentSpeed = 10f;
    public float rotX;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // move with Horizontal and Vertical axis
        var dir = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        transform.position += dir * movemmentSpeed * Time.deltaTime;

        // rotate/ move sideways with Mouse X axis
        rotX += Input.GetAxis("Mouse X");
        cam.transform.localEulerAngles = new Vector3(0, rotX * Time.deltaTime, 0);
        transform.transform.rotation = cam.transform.rotation;
    }
}
