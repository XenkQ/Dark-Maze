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

    private enum EnemyState
    {
        Normal,
        Chasing,
        Searching
    }

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

    private void Update()
    {
        EnemyStateMachina();

        Debug.Log(player.transform.tag);
        if (PlayerInRadius() && player.transform.tag == "Player" && enemyState != EnemyState.Chasing)
        {
            enemyState = EnemyState.Chasing;
        }
        if(!PlayerInRadius() && enemyState == EnemyState.Chasing)
        {
            SetRandomDestination();
            enemyState = EnemyState.Normal;
        }
        if(PlayerInRadius() && player.transform.tag == "UnkillablePlayer" && enemyState == EnemyState.Chasing)
        {
            StartCoroutine(SearchingMode());
        }
    }

    private IEnumerator SearchingMode()
    {
        enemyState = EnemyState.Searching;
        Debug.Log("Szukam");
        animator.SetBool("isSearching", true);
        navMeshAgent.isStopped = true;
        yield return new WaitForSeconds(searchingTime);
        SetRandomDestination();
        animator.SetBool("isSearching", false);
        navMeshAgent.isStopped = false;
        enemyState = EnemyState.Normal;
        Debug.Log("Skoñczy³em szukaæ");
    }

    private void EnemyStateMachina()
    {
        switch(enemyState)
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

    private bool PlayerInRadius()
    {
        if (Mathf.CeilToInt(Vector3.Distance(player.transform.position, this.transform.position)) <= enemyRadius)
        {
            return true;
        }
        return false;
    }

    private void ChasePlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }

    private void OnDrawGizmos()
    {
        DrawDistance(enemyRadius, Color.red, yOffset);
    }

    private void DrawDistance(float distance, Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(this.transform.position, distance);
    }

    private void DrawDistance(float distance, Color color, float yOffset)
    {
        Gizmos.color = color;
        Gizmos.DrawWireSphere(new Vector3
            (this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z), distance);
    }

    private void ChangeDestinationAfterReach()
    {
        if (Vector3.Distance(this.transform.position, currentDestination) < distanceToChangePoint)
        {
            SetRandomDestination();
        }
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

    private void RotateAtPlayerDirection()
    {
        Vector3 dir = player.transform.position - transform.position;
        dir.y = 0;
        var rotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }
}
