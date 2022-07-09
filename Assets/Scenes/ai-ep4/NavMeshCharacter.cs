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

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetDestination();
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
