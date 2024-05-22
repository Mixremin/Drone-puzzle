using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private enum EnemyState
    {
        Idle,
        Following,
        Attack
    }



    [Header("NavMesh Settings")]
    [SerializeField]
    private float acceleration = 2f;

    [SerializeField]
    private float deceleration = 60f;

    [SerializeField]
    private float closeEnoughMeters = 4f;

    [SerializeField]
    private float attackRange = 0f;

    [Header("Technical")]
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private GameObject player;


    [SerializeField]
    private EnemyState enemyState;

    [Header("Combat")]
    [SerializeField]
    private EnemyRangeCombat rangeCombatController;



    private readonly int triggerIDDeath;
    private int triggerIDAttack;
    private int triggerIDMoving;
    private NavMeshAgent navMeshAgent;



    private void AssignAnimationIDs()
    {
        triggerIDAttack = Animator.StringToHash("Attack");
        triggerIDMoving = Animator.StringToHash("Moving");
    }

    // Start is called before the first frame updat
    private void Awake()
    {
        anim = GetComponent<Animator>();
        AssignAnimationIDs();
        rb = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");

    }

    [System.Obsolete]
    private void Update()
    {
        Vector3 playerDirection = player.transform.position - transform.position;
        float DistanceToPlayer = playerDirection.magnitude;


        _ = Physics.Raycast(transform.position + new Vector3(0.0f, 1.0f, 0.0f), playerDirection, out RaycastHit hit, Mathf.Infinity);
        Debug.DrawRay(transform.position + new Vector3(0.0f, 1.0f, 0.0f), playerDirection * 1000.0f, Color.yellow);


        FaceTarget(player.transform.position);
        SlideControll();

        if (DistanceToPlayer <= attackRange && hit.transform.gameObject.CompareTag("Player"))
        {
            enemyState = EnemyState.Idle;
            rangeCombatController.Attack();

        }
        else if (enemyState != EnemyState.Following)
        {
            enemyState = EnemyState.Following;
        }

        switch (enemyState)
        {
            case EnemyState.Idle:
                StopChasePlayer();
                break;
            case EnemyState.Following:
                ChasePlayer();
                break;
        }
    }

    private void ChasePlayer()
    {
        anim.SetBool(triggerIDMoving, true);
        navMeshAgent.isStopped = false;
        _ = navMeshAgent.SetDestination(player.transform.position);
        //FaceTarget(player.transform.position);
    }

    private void StopChasePlayer()
    {
        if (!navMeshAgent.isStopped)
        {
            _ = navMeshAgent.SetDestination(transform.position);
            rb.velocity = Vector3.zero;
            enemyState = EnemyState.Idle;
            anim.SetBool(triggerIDMoving, false);
        }
    }

    private void SlideControll()
    {
        if (navMeshAgent.hasPath)
        {
            navMeshAgent.acceleration = (navMeshAgent.remainingDistance < closeEnoughMeters) ? deceleration : acceleration;
        }

    }

    public void DeathRemove()
    {
        Destroy(navMeshAgent);
        Destroy(rangeCombatController);
        Destroy(this);
    }

    private void FaceTarget(Vector3 destination)
    {
        Vector3 lookPos = destination - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 150);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0.0f, 0.75f, 0.0f), attackRange);
    }
}
