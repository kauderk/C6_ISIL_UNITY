using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEvents : MonoBehaviour
{
    // make this a singleton
    public static PointEvents instance;
    public static int creationCounter;
    [SerializeField]
    public GameObject[] points = new GameObject[1];
    public static Action OnResetPoints;
    public static Action<GameObject> OnPointCreated;
    public static Action<GameObject[]> OnStarEndCreated;
    public static Action<NavMesh> OnPathFinding;
    public static NavMesh GState = NavMesh.Selecting;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        OnPointCreated += OnPointCreatedHandler;
        OnPathFinding += OnPathFindingHandler;
    }

    private void OnPathFindingHandler(NavMesh state)
    {
        // get state name
        string stateName = Enum.GetName(typeof(NavMesh), state);
        if (state == NavMesh.Selecting || state == NavMesh.Arrived)
        {
            Debug.Log("NavMesh state only: " + stateName);
        }
        GState = state;
    }

    private void OnPointCreatedHandler(GameObject obj)
    {
        var mesh = obj.GetComponents<MeshRenderer>()[0];
        var color = creationCounter % 1 == 0 ? Color.red : Color.blue;
        mesh.material.color = color;
        points[creationCounter] = obj;
        mutateCounter();
    }

    public void mutateCounter()
    {
        creationCounter++;
        if (creationCounter > 1)
        {
            creationCounter = 0;
            OnStarEndCreated?.Invoke(points);
            points[0] = null;
            points[1] = null;
        }
    }
}
