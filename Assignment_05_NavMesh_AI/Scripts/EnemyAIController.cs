using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Practical 5: NavMesh AI Enemy Controller
/// Uses Unity's NavMeshAgent to pathfind around obstacles and intelligently chase the player or patrol waypoints.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAIController : MonoBehaviour
{
    public enum AIState { Patrol, Chase, StopInRange }

    [Header("Target & Detection")]
    [Tooltip("The player transform that the AI will detect and pursue.")]
    [SerializeField] private Transform playerTarget;

    [Tooltip("Distance at which the AI detects the player and begins chasing.")]
    [SerializeField] private float detectionRadius = 10f;

    [Tooltip("Distance at which the AI stops to attack/interact.")]
    [SerializeField] private float attackRange = 2f;

    [Header("Patrol Waypoints")]
    [Tooltip("List of patrol waypoint transforms.")]
    [SerializeField] private Transform[] waypoints;
    private int currentWaypointIndex = 0;

    [Header("Movement Speeds")]
    [SerializeField] private float patrolSpeed = 3.5f;
    [SerializeField] private float chaseSpeed = 6f;

    private NavMeshAgent agent;
    private AIState currentState = AIState.Patrol;

    public AIState CurrentState => currentState;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        // If player is not explicitly assigned in inspector, attempt auto-finding by Tag
        if (playerTarget == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) playerTarget = playerObj.transform;
        }

        // Set initial speed
        agent.speed = patrolSpeed;
        GoToNextWaypoint();
    }

    private void Update()
    {
        if (playerTarget == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.position);

        // State Machine Decision Logic
        if (distanceToPlayer <= attackRange)
        {
            // Within attack distance: stop and face player
            currentState = AIState.StopInRange;
            agent.isStopped = true;
            FaceTarget(playerTarget.position);
        }
        else if (distanceToPlayer <= detectionRadius)
        {
            // Player is within vision range: switch to Chase mode
            currentState = AIState.Chase;
            agent.isStopped = false;
            agent.speed = chaseSpeed;
            agent.SetDestination(playerTarget.position);
        }
        else
        {
            // Player escaped: return to regular patrol route
            currentState = AIState.Patrol;
            agent.isStopped = false;
            agent.speed = patrolSpeed;

            // When agent is close to the current waypoint, cycle to the next
            if (!agent.pathPending && agent.remainingDistance < 0.8f)
            {
                GoToNextWaypoint();
            }
        }
    }

    private void GoToNextWaypoint()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        agent.SetDestination(waypoints[currentWaypointIndex].position);
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }

    private void FaceTarget(Vector3 targetPos)
    {
        Vector3 direction = (targetPos - transform.position).normalized;
        direction.y = 0; // Keep horizontal rotation
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize detection radius as a yellow wire sphere in Scene view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        // Visualize attack/stop range as a red wire sphere
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
