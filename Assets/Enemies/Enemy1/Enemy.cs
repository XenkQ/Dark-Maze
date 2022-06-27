using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Enemy1AnimationsManager))]
public class Enemy : MonoBehaviour
{
    [Header("Targets")]
    private Player player;

    [Header("Rotation")]
    [SerializeField] private int rotationSpeed = 8;

    [Header("EnemyPaths")]
    [SerializeField] private Transform[] spawnPointTransforms;
    [SerializeField] private float distanceToChangePoint = 4;
    private Vector3 currentDestination;
    private Vector3 lastDestination;

    [Header("player interactions")]
    [SerializeField] [Range(1, 25)] private int enemyRadius;
    public int EnemyRadius { get { return enemyRadius; } }
    [SerializeField] private EnemyState enemyState;
    [SerializeField] private float searchingTime;

    [Header("Compontents")]
    private NavMeshAgent navMeshAgent;

    [Header("Other Scripts")]
    private Enemy1AnimationsManager animationsMenager;

    [Header("Objects")]
    private Camera playerCamera;

    [Header("Enemy is visible ray")]
    [SerializeField] private LayerMask obstacleMask;
    [SerializeField] private float maxDistanceTheOpponentCanBeSeen = 20f;

    [Header("Colliders")]
    [SerializeField] private BoxCollider headCollider;
    [SerializeField] private BoxCollider spineCollider;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animationsMenager = GetComponent<Enemy1AnimationsManager>();
        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Camera>();
    }

    private void Start()
    {
        enemyState = EnemyState.Normal;
        SetRandomDestination();
    }

    private void FixedUpdate()
    {
        EnemyStateMachine();
        ChangeDestinationAfterReach();

        if(IsVisibleByCamera())
        {
            Debug.Log("isVisible" + transform.name);
        }
    }

    private void EnemyStateMachine()
    {
        SetChasingEnemyStateIfPlayerInRadiusAndPastStateOtherThenChasing();

        StopChasingPlayerIfPlayerOutOfRadiusAndPastStateEqualsToChasing();

        SearchForPlayerIfPlayerInSchoolLockerAndInRadius();

        EnemyActionsRelatedToState();
    }

    private void SetChasingEnemyStateIfPlayerInRadiusAndPastStateOtherThenChasing()
    {
        if (PlayerInRadius() && player.transform.tag == "Player" && enemyState != EnemyState.Chasing)
        {
            enemyState = EnemyState.Chasing;
        }
    }

    private void StopChasingPlayerIfPlayerOutOfRadiusAndPastStateEqualsToChasing()
    {
        if (!PlayerInRadius() && enemyState == EnemyState.Chasing)
        {
            enemyState = EnemyState.Normal;
        }
    }

    private void SearchForPlayerIfPlayerInSchoolLockerAndInRadius()
    {
        if (PlayerInRadius() && player.transform.tag == "UnkillablePlayer" && enemyState == EnemyState.Chasing)
        {
            enemyState = EnemyState.Searching;
        }
    }
    private bool PlayerInRadius()
    {
        if (Mathf.CeilToInt(Vector3.Distance(player.transform.position, this.transform.position)) <= enemyRadius)
        {
            return true;
        }
        return false;
    }

    private void ChangeDestinationAfterReach()
    {
        if (Vector3.Distance(this.transform.position, currentDestination) < distanceToChangePoint)
        {
            SetRandomDestination();
        }
    }

    private void StopEnemyMovement()
    {
        if (navMeshAgent.isStopped == false)
        {
            navMeshAgent.isStopped = true;
        }
    }

    private void ResumeEnemyMovement()
    {
        if (navMeshAgent.isStopped == true)
        {
            navMeshAgent.isStopped = false;
        }
    }

    private void SetRandomDestination()
    {
        Debug.Log("Zmiana");
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

    private Vector3 GetRandomDestinationPointPosition()
    {
        return GetRandomDestinationPoint().position;
    }

    private Transform GetRandomDestinationPoint()
    {
        return spawnPointTransforms[Random.Range(0, spawnPointTransforms.Length)];
    }

    private void EnemyActionsRelatedToState()
    {
        switch (enemyState)
        {
            case EnemyState.Normal:
                ChangeBackToCurrentDestination();
                break;

            case EnemyState.Chasing:
                RotateAtPlayerDirection();
                ChasePlayer();
                break;

            case EnemyState.Searching:
                StartCoroutine(LookAroundProcess());
                break;
        }
    }

    private void ChangeBackToCurrentDestination()
    {
        navMeshAgent.destination = currentDestination;
    }

    private void RotateAtPlayerDirection()
    {
        Vector3 dir = player.transform.position - transform.position;
        dir.y = 0;
        var rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }

    private void ChasePlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }

    private IEnumerator LookAroundProcess()
    {
        Debug.Log("State: " + enemyState);
        LookAround();
        yield return new WaitForSeconds(searchingTime);
        StopLookingAround();
    }

    private void LookAround()
    {
        enemyState = EnemyState.Searching;
        animationsMenager.StartSearchingAnimation();
        StopEnemyMovement();
        Debug.Log("Searching");
    }

    private void StopLookingAround()
    {
        ChangeBackToCurrentDestination();
        animationsMenager.StopSearchingAnimation();
        ResumeEnemyMovement();
        enemyState = EnemyState.Normal;
        Debug.Log("Searching Ended");
    }

    public bool IsVisibleByCamera()
    {
        return IsCameraTurnedInEnemyDirection() == true && IsTargetBehindObstacle() == false;
    }

    public bool IsTargetBehindObstacle()
    {
        Vector3 targetPos = playerCamera.transform.position;
        Vector3 dirToTarget = (targetPos - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, playerCamera.transform.position);

        if(!Physics.Raycast(transform.position, dirToTarget, distanceToTarget, obstacleMask))
        {
            Debug.DrawLine(transform.position, targetPos, Color.blue);
            return false;
        }
        else
        {
            Debug.DrawLine(transform.position, targetPos, Color.red);
            return true;
        }
    }

    private bool IsCameraTurnedInEnemyDirection()
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(playerCamera);

        if (GeometryUtility.TestPlanesAABB(planes, spineCollider.bounds) || GeometryUtility.TestPlanesAABB(planes, headCollider.bounds))
        {
            return true;
        }

        return false;
    }
}
