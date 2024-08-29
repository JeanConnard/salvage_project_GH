using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] GameObject zombie = null;
    [SerializeField] GameObject target = null;
    [SerializeField] NavMeshAgent agent = null;

    //Animation
    [SerializeField] Animator zombieAnimator = null;
    [SerializeField] ZombieAnimation animations = null;

    private void Awake()
    {
        zombie = this.gameObject;
        zombie.SetActive(false);
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animations = GetComponent<ZombieAnimation>();
        zombieAnimator = GetComponent<Animator>();

        //ZombieSpawner.OnTimerEnd += Appear;
    }

    void Update()
    {
  
    }

    //void Appear()
    //{
    //    zombie.SetActive(true);
    //}

    private void FixedUpdate() 
    {
        if (!target || !agent || !agent.enabled) return;
        agent.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (!agent || collision.gameObject.layer != 13) return;
        animations.UpdateAttackAnimatorParam(true);
        agent.enabled = false;
        Invoke("ReStart", 1);
    }

    void ReStart()
    {
        animations.UpdateAttackAnimatorParam(false);
        agent.enabled = true;
    }


    #region travail Patrick
    /*
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
    }*/
    #endregion
}
