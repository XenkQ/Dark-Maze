using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [Header("Rotation")]
    private GameObject player;
    [SerializeField] private int rotationSpeed = 8;

    [Header("EnemyPaths")]
    [SerializeField] private bool lookForPath = true;
    [SerializeField] private Transform[] spawnPointTransforms;
    private Vector3 currentDestination;
    private Vector3 lastDestination;
    [SerializeField] private float distanceToChangePoint = 4;

    [Header("Enemy - player interactions")]
    [SerializeField] [Range(1, 25)] private int enemyRadius;
    [SerializeField] [Range(-10f, 10f)] private float yOffset = 1f;
    [SerializeField] private EnemyState enemyState;
    [SerializeField] private float searchingTime;
    [SerializeField] private List<Transform> schoolLockers;

    [Header("Enemy Compontents")]
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        enemyState = EnemyState.Normal;
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        if(lookForPath)
        {
            SetRandomDestination();
        }
    }

    private void OnDrawGizmos()
    {
        DrawEnemyRadiusInFormOfSphere(enemyRadius, Color.red, yOffset);
    }

    private void Update()
    {
        EnemyStateMachine();
    }

    private IEnumerator SearchingMode()
    {
        enemyState = EnemyState.Searching;
        Debug.Log("Searching");
        animator.SetBool("isSearching", true);
        navMeshAgent.isStopped = true;
        yield return new WaitForSeconds(searchingTime);
        SetRandomDestination();
        animator.SetBool("isSearching", false);
        navMeshAgent.isStopped = false;
        enemyState = EnemyState.Normal;
        Debug.Log("Searching Ended");
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
            SetRandomDestination();
            enemyState = EnemyState.Normal;
        }
    }

    private void SearchForPlayerIfPlayerInSchoolLockerAndInRadius()
    {
        if (PlayerInRadius() && player.transform.tag == "UnkillablePlayer" && enemyState == EnemyState.Chasing)
        {
            StartCoroutine(SearchingMode());
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

    private void EnemyActionsRelatedToState()
    {
        switch (enemyState)
        {
            case EnemyState.Normal:
                ChangeDestinationAfterReach();
                break;

            case EnemyState.Chasing:
                RotateAtPlayerDirection();
                ChasePlayer();
                break;

            case EnemyState.Searching:
                //SeachForPlayer()
                break;
        }
    }

    private void ChangeDestinationAfterReach()
    {
        if (Vector3.Distance(this.transform.position, currentDestination) < distanceToChangePoint)
        {
            SetRandomDestination();
        }
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

    private void DrawEnemyRadiusInFormOfSphere(float radius, Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }

    private void DrawEnemyRadiusInFormOfSphere(float radius, Color color, float yOffset)
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(new Vector3
            (this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z), radius);
    }

    private void SetRandomDestination()
    {
        if(lastDestination != null)
        {
            lastDestination = currentDestination;
            do
            {
                currentDestination = spawnPointTransforms[Random.Range(0, spawnPointTransforms.Length)].position;
            }
            while (lastDestination == currentDestination);
            navMeshAgent.destination = currentDestination;
        }
        else
        {
            currentDestination = spawnPointTransforms[Random.Range(0, spawnPointTransforms.Length)].position;
        }
    }
}
