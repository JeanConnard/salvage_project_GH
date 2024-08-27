using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float stoppingDistance = 2.5f, attackRange = 1.5f, attackCooldown = 2f;
    [SerializeField] private string isRunningBool = "isRunning";
    [SerializeField] private string attackTrigger = "Attack";
    private float lastAttackTime;
    private bool playerDetected = false;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange)
        {
            playerDetected = true;
        }
        if (playerDetected)
        {
            agent.SetDestination(player.position);

            if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
            {
                Attack();
            }
            else if (distanceToPlayer <= stoppingDistance)
            {
                agent.isStopped = true;
                animator.SetBool("isRunning", false);
            }
            else
            {
                agent.isStopped = false;
                agent.speed = 4f;
                animator.SetBool("isRunning", true);
            }
        }
        else
        {
            agent.isStopped = false;
            agent.speed = 2f;
            animator.SetBool("isRunning", false);
        }
    }
    void Attack()
    {
       animator.SetTrigger("Attack");
       Debug.Log("Zombie attaque le joueur !");
       lastAttackTime = Time.time;
    }
}
