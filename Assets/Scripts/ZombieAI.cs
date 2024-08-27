using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    private NavMeshAgent agent;

    [SerializeField] private float stoppingDistance = 2.5f, attackRange = 1.5f, attackCooldown = 2f;
    private float lastAttackTime;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        agent.SetDestination(player.position);
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
        }
    }
    private void Attack()
    {
        //Attack
        Debug.Log("Zombie attaque le joueur !");
        lastAttackTime = Time.time;
    }
}
