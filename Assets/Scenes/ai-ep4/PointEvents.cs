using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEvents : MonoBehaviour
{
    // make this a singleton
    public static PointEvents instance;
    public static int creationCounter;
    public GameObject[] points;
    public static Action<GameObject> OnResetPoints;
    public static Action<GameObject> OnPointCreated;
    public static Action<GameObject[]> OnStarEndCreated;
    public static NavMesh GlobalNavMeshState = NavMesh.Idle;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        OnPointCreated += OnPointCreatedHandler;
    }

    private void OnPointCreatedHandler(GameObject obj)
    {
        var mesh = obj.GetComponents<MeshRenderer>()[0];
        var color = creationCounter % 2 == 0 ? Color.red : Color.blue;
        mesh.material.color = color;
        points[creationCounter] = obj;
        mutateCounter();
    }

    public void mutateCounter()
    {
        creationCounter++;
        if (creationCounter > 1)
        {
            OnStarEndCreated?.Invoke(points);
            creationCounter = 0;
        }
    }
}
