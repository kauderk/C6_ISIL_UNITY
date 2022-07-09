using UnityEngine;
using System.Collections;

public class NavCameraController : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex;

    // Use this for initialization
    void Start()
    {
        currentCameraIndex = 0;

        //Turn all cameras off, except the first default one
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        //If any cameras were added to the controller, enable the first one
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
            Debug.Log("Camera with name: " + cameras[0].camera.name + ", is now enabled");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If the c button is pressed, switch to the next camera
        //Set the camera at the current index to inactive, and set the next one in the array to active
        //When we reach the end of the camera array, move back to the beginning or the array.
        if (Input.GetKeyDown(KeyCode.r))
        {
            currentCameraIndex++;
            if (currentCameraIndex < cameras.Length)
                NewMethod(currentCameraIndex);
            else
                NewMethod(0);
            Debug.Log("Camera with name: " + cameras[currentCameraIndex].camera.name + ", is now enabled");
        }
    }

    private void NewMethod(int idx)
    {
        cameras[idx - 1].gameObject.SetActive(false);
        currentCameraIndex = idx; // BAD IDEA!!!!!
        cameras[idx].gameObject.SetActive(true);
    }
}