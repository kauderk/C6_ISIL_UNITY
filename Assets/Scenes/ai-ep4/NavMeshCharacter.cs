using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshCharacter : MonoBehaviour
{
    [SerializeField]
    private Transform destination;

    NavMeshAgent navMeshAgent;
    public static Action<NavMesh> OnPathFinding;

    private NavMesh pathState = NavMesh.Idle;

    void Start()
    {
        PointEvents.OnResetPoints += HandleOnOnResetPoints;
        PointEvents.OnStarEndCreated += HandleOnStarEndCreated;
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetDestination();
        tooglepNavMesh(false);
    }

    private void Update()
    {
        if (ReachedDestination())
        {
            Debug.Log("Reached destination");
            OnPathFinding?.Invoke(NavMesh.Arrived);
        }
    }

    private void HandleOnOnResetPoints(GameObject obj)
    {
        tooglepNavMesh(false);
    }

    private void tooglepNavMesh(bool b = true)
    {
        navMeshAgent.enabled = b;
        var state = b ? NavMesh.Moving : NavMesh.Arrived;
        OnPathFinding?.Invoke(state);
    }

    private void HandleOnStarEndCreated(GameObject[] obj)
    {
        transform.position = obj[0].transform.position;
        GetComponent<NavMeshAgent>().SetDestination(obj[1].transform.position);
        tooglepNavMesh(true);
    }

    public bool ReachedDestination()
    {
        // Check if we've reached the destination
        if (!navMeshAgent.pathPending)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void SetDestination()
    {
        if (destination != null)
        {
            navMeshAgent.SetDestination(destination.position);
        }
        else
        {
            Vector3 target = destination.transform.position;
            navMeshAgent.SetDestination(target);
        }
    }
}
public enum NavMesh
{
    Idle,
    Moving,
    Arrived,
    Error
}
