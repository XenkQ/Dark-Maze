using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy1AnimationsManager),typeof(NavMeshAgent), typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{
    [Header("Targets")]
    private Player player;

    [Header("Enemy Behaviours")]
    [SerializeField] [Range(1, 25)] private int enemyRadius;
    public int EnemyRadius { get { return enemyRadius; } }
    [SerializeField] private EnemyState enemyState;
    [SerializeField] private float searchingTime;

    [Header("Other Scripts")]
    private EnemyMovement enemyMovement;
    private Enemy1AnimationsManager animationsMenager;

    [Header("Objects")]
    private Camera playerCamera;

    [Header("Enemy is visible ray")]
    [SerializeField] private LayerMask obstacleMask;
    [SerializeField] private float maxDistanceTheOpponentCanBeSeen = 20f;

    [Header("Colliders")]
    [SerializeField] private BoxCollider headCollider;
    [SerializeField] private BoxCollider spineCollider;

    private NavMeshAgent navMeshAgent;
    public static bool atLeastOneOpponentVisible;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animationsMenager = GetComponent<Enemy1AnimationsManager>();
        enemyMovement = GetComponent<EnemyMovement>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Camera>();
    }

    private void Start()
    {
        enemyState = EnemyState.Normal;
    }

    private void FixedUpdate()
    {
        EnemyStateMachine();

        if(IsVisibleByCamera())
        {

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

    private void EnemyActionsRelatedToState()
    {
        switch (enemyState)
        {
            case EnemyState.Normal:
                enemyMovement.ChangeBackToCurrentDestination();
                break;

            case EnemyState.Chasing:
                enemyMovement.RotateAtDirection(player.transform.position);
                ChasePlayer();
                break;

            case EnemyState.Searching:
                StartCoroutine(LookAroundProcess());
                break;
        }
    }

    private void ChasePlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }

    private IEnumerator LookAroundProcess()
    {
        LookAround();
        yield return new WaitForSeconds(searchingTime);
        StopLookingAround();
    }

    private void LookAround()
    {
        enemyState = EnemyState.Searching;
        animationsMenager.StartSearchingAnimation();
        enemyMovement.StopEnemyMovement();
    }

    private void StopLookingAround()
    {
        enemyMovement.ChangeBackToCurrentDestination();
        animationsMenager.StopSearchingAnimation();
        enemyMovement.ResumeEnemyMovement();
        enemyState = EnemyState.Normal;

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
