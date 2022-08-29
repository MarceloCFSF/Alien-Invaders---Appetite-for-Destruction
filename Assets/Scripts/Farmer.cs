using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Farmer : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    
    public LayerMask playerLayer;
    public LayerMask obstructionMask;

    public float radius = 5f;
    [Range(0, 360)]
    public float angle;

    public bool canSeePlayer = false;
    
    public float wanderRadius = 5f;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
        target = GameObject.Find("Player").transform;
        target = GameObject.Find("Player").transform;

        animator = gameObject.GetComponent<Animator>();

        StartCoroutine(FOVRoutine());
    }

    void Update() {
        if (canSeePlayer) {
            agent.SetDestination(target.position);
        } else {
            Wander();
        }
        Animation();
    }

    void Animation() {
        animator.SetFloat("Horizontal", agent.velocity.x);
        animator.SetFloat("Vertical", agent.velocity.y);
    }

    Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask) {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
        
        randomDirection += origin;
        
        NavMeshHit navHit;
        
        NavMesh.SamplePosition (randomDirection, out navHit, distance, layermask);
        
        return navHit.position;
    }

    void Wander() {
        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
        agent.SetDestination(newPos);
    }

    private IEnumerator FOVRoutine() {
        float delay = 0.05f;

        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true) {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            Player player = other.gameObject.GetComponent<Player>();

            if (player) {
                player.TakeDamage(20);
            }
        }
    }

    void FieldOfViewCheck() {
        Collider2D[] rangeChecks = Physics2D.OverlapCircleAll(transform.position, radius, playerLayer);

        if(rangeChecks.Length > 0) {
            Transform target = rangeChecks[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if(Vector2.Angle(-transform.up, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                bool inRange = !Physics2D.Raycast(
                    transform.position, directionToTarget, distanceToTarget, obstructionMask
                );
                if(inRange) {
                    canSeePlayer = true;
                } else canSeePlayer = false;
            } else canSeePlayer = false;
        } else if(canSeePlayer) canSeePlayer = false;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        Vector3 angle01 = DirectionFromAngle(-transform.eulerAngles.z, -angle / 2);
        Vector3 angle02 = DirectionFromAngle(-transform.eulerAngles.z, angle / 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - angle01 * radius);
        Gizmos.DrawLine(transform.position, transform.position - angle02 * radius);

        if (canSeePlayer) {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, target.position);
        }
    }

    private Vector2 DirectionFromAngle(float eulerY, float angleInDegrees) {
        angleInDegrees += eulerY;

        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
