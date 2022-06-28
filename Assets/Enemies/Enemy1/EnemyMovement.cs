using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private int rotationSpeed = 8;

    [Header("Enemy Paths")]
    [SerializeField] private Transform[] destinationPoints;
    [SerializeField] private float distanceToChangePoint = 4;
    private Vector3 currentDestination;
    private Vector3 lastDestination;

    [Header("Components")]
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        SetRandomDestination();
    }

    private void FixedUpdate()
    {
        ChangeDestinationAfterReach();
    }

    public void StopEnemyMovement()
    {
        if (navMeshAgent.isStopped == false)
        {
            navMeshAgent.isStopped = true;
        }
    }

    public void ResumeEnemyMovement()
    {
        if (navMeshAgent.isStopped == true)
        {
            navMeshAgent.isStopped = false;
        }
    }

    private void ChangeDestinationAfterReach()
    {
        if (Vector3.Distance(transform.position, currentDestination) < distanceToChangePoint)
        {
            SetRandomDestination();
        }
    }

    public void ChangeBackToCurrentDestination()
    {
        navMeshAgent.destination = currentDestination;
    }

    private void SetRandomDestination()
    {
        if (lastDestination != null)
        {
            lastDestination = currentDestination;
            do
            {
                currentDestination = GetRandomDestinationPointPosition();
            }
            while (lastDestination == currentDestination);
            navMeshAgent.destination = currentDestination;
        }
        else
        {
            currentDestination = GetRandomDestinationPointPosition();
        }
    }

    public void RotateAtDirection(Vector3 direciton)
    {
        Vector3 rotateDirection = direciton - transform.position;
        rotateDirection.y = 0;
        var rotation = Quaternion.LookRotation(rotateDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }

    private Vector3 GetRandomDestinationPointPosition()
    {
        return GetRandomDestinationPoint().position;
    }

    private Transform GetRandomDestinationPoint()
    {
        return destinationPoints[Random.Range(0, destinationPoints.Length)];
    }
}
