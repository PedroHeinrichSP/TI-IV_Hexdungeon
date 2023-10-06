using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;           // Reference to the player's transform.
    public float movementSpeed = 5f;   // Enemy movement speed.
    public float approachRange = 10f;  // Enemy approach range.
    public float attackRange = 2f;     // Enemy attack range.

    private Animator animator;
    private NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component of the enemy.

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("PlayerObject").transform;
    }

    void Update()
    {
        // Set the player's position as the destination.
        navMeshAgent.SetDestination(player.position);

        // If the distance between the enemy and the player is less than or equal to the attack range...
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }

        // If the distance between the enemy and the player is less than or equal to the approach range...
        else if (Vector3.Distance(transform.position, player.position) <= approachRange)
        {
            // Set the movement speed.
            animator.SetTrigger("Walk");
            navMeshAgent.speed = movementSpeed;
        }
        
        else
        {
            // Set the movement speed.
            animator.SetTrigger("Idle");
            navMeshAgent.speed = 0;
        }
        
    }
}
