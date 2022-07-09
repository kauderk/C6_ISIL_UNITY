using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class NavCameraController : MonoBehaviour
{
    [SerializeField]
    public List<cameraSet> cameras = new List<cameraSet>();
    [SerializeField]
    public Dictionary<cams, Camera> camerasDict = new Dictionary<cams, Camera>();
    [SerializeField]
    private cams lastCamera = cams.selection;

    private void Awake()
    {
        foreach (cameraSet camera in cameras)
        {
            camerasDict[camera.id] = camera.camera;
        }
        PointEvents.OnResetPoints += HandleOnResetPoints;
    }
    private void Start()
    {
        PointEvents.OnStarEndCreated += HandleOnStarEndCreated;
        EnableCamera(lastCamera = cams.selection);
    }

    private void HandleOnResetPoints()
    {
        EnableCamera(cams.selection);
        PointEvents.OnPathFinding?.Invoke(PointEvents.GState = NavMesh.Selecting);
    }

    private void HandleOnStarEndCreated(GameObject[] obj)
    {
        EnableCamera(cams.player);
        PointEvents.OnPathFinding?.Invoke(PointEvents.GState = NavMesh.ReadyToMove);
    }

    // Use this for initialization
    private void EnableCamera(cams id)
    {

        if (camerasDict[id].enabled)
            return; // don't enable the same camera twice

        //Turn all cameras off in camerasDict
        foreach (var entry in camerasDict)
            entry.Value.enabled = false;

        //If any cameras were added to the controller, enable the first one
        camerasDict[id].enabled = true;

        Debug.Log("Enabled camera " + id);
        if (id == cams.selection)
            PointEvents.OnPathFinding?.Invoke(PointEvents.GState = NavMesh.Selecting);
        else
            PointEvents.OnPathFinding?.Invoke(PointEvents.GState = NavMesh.ReadyToMove);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            var nextCamId = (cams)(((int)lastCamera + 1) % cameras.Count);
            EnableCamera(nextCamId);
        }
    }
}
[System.Serializable]
public class cameraSet
{
    public cams id;
    public Camera camera;
}
[System.Serializable]
public enum cams
{
    player,
    selection,
}