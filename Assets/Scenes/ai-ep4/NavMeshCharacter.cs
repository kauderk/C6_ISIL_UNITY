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
    private Vector3 chasedPosition;
    private GameObject[] cashStartEndPoints = new GameObject[1];

    NavMeshAgent navMeshAgent;

    private void Awake()
    {
        chasedPosition = GetComponent<Transform>().position;
        PointEvents.OnStarEndCreated += HandleOnStarEndCreated;
    }

    void Start()
    {
        PointEvents.OnPathFinding += HandleOnPathFinding;
        PointEvents.OnResetPoints += HandleOnOnResetPoints;
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetDestination();
        tooglepNavMesh(false);
    }

    private void HandleOnPathFinding(NavMesh state)
    {
        if (state == NavMesh.ReadyToMove && cashStartEndPoints[0] != null)
        {
            tooglepNavMesh(true);
            transform.position = cashStartEndPoints[0].transform.position;
            SetDestination(cashStartEndPoints[1].transform);
            // empty cashStartEndPoints
            cashStartEndPoints[0] = null;
            cashStartEndPoints[1] = null;
            PointEvents.OnPathFinding?.Invoke(PointEvents.GState = NavMesh.Moving);
        }
    }

    private void Update()
    {
        if (ReachedDestination())
        {
            tooglepNavMesh(false);
            Debug.Log("Reached destination");
            PointEvents.OnPathFinding?.Invoke(PointEvents.GState = NavMesh.Arrived);
        }
    }

    private void HandleOnOnResetPoints()
    {
        transform.position = chasedPosition;
        tooglepNavMesh(false);
    }

    private void tooglepNavMesh(bool b = true)
    {
        navMeshAgent.enabled = b;
        // var state = b ? NavMesh.Moving : NavMesh.Arrived;
        // PointEvents.OnPathFinding?.Invoke(state);
    }

    private void HandleOnStarEndCreated(GameObject[] obj)
    {
        cashStartEndPoints = obj;
    }

    public bool ReachedDestination()
    {
        if (!navMeshAgent.isOnNavMesh)
            return false;
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

    private void SetDestination(Transform overrideDes = null)
    {
        destination = overrideDes ?? destination;
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
    Selecting,
    Moving,
    Arrived,
    ReadyToMove
}
