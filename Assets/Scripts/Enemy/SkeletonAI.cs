using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pathfinding {
public class SkeletonAI : VersionedMonoBehaviour
    {
    public Transform[] targets;
        private Transform player;
        public bool isStationary;
        int index;
        IAstarAI agent;
        float switchTime = float.PositiveInfinity;
        bool playerInRange = false;
        public float delay = 0;
        Animator animator;

        private float lastAttackTime;
        private bool isAttacking = false;
        private float attackDelay = 1.10f;
        private float attackTime = 1.10f;
        public float attackRange;
        [SerializeField]
        private float maxRange;
        [SerializeField]
        private float minRange;



        protected override void Awake()
        {
            base.Awake();
            agent = GetComponent<IAstarAI>();
            index = Random.Range(0, targets.Length);
            animator = GetComponentInChildren<Animator>();
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Update is called once per frame
        void Update()
        {
            if (Vector3.Distance(player.position, agent.position) <= maxRange && (Vector3.Distance(player.position, agent.position) > minRange))
            {
                playerInRange = true;
            }

            if (isAttacking)
            {
                agent.isStopped = true;
                attackDelay -= Time.deltaTime;
                if (attackDelay <= 0)
                {
                    animator.SetBool("isAttacking", false);
                    attackDelay = attackTime;
                    isAttacking = false;
                    agent.isStopped = false;
                }
                return;
            }

            if (playerInRange)
            {   
                float distanceToPlayer = Vector3.Distance(agent.position, player.position);
                if (distanceToPlayer < attackRange) {
                   animator.SetBool("isAttacking", true);
                   isAttacking = true;
                } else {
                    FollowPlayer();
                }
            }
            else
            {
                if (isStationary)
                {
                    animator.SetBool("isPatrolling", false);
                }
                Patrol();
            }
        }

        void FollowPlayer()
        {
            animator.SetBool("playerInRange", true);
            agent.destination = player.position;
            animator.SetFloat("moveX", agent.desiredVelocity.x);
            animator.SetFloat("moveY", agent.desiredVelocity.y);
            agent.SearchPath();
        }

        void Patrol()
        {
            if (targets.Length == 0 || playerInRange) return;
            bool search = false;
            if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime))
            {
                animator.SetBool("patrolling", false);
                switchTime = Time.time + delay;
            }

            if (Time.time >= switchTime)
            {
                index = Random.Range(0, targets.Length);
                search = true;
                switchTime = float.PositiveInfinity;
                animator.SetBool("patrolling", true);
            }

            agent.destination = targets[index].position;
            animator.SetFloat("moveX", targets[index].position.x - agent.position.x);
            animator.SetFloat("moveY", targets[index].position.y - agent.position.y);
            if (search) agent.SearchPath();
        }

        /*
        private void OnTriggerEnter2D(Collider2D other){
            if (other.tag == "MyWeapon" && gameObject.tag != "Hitbox")
            {
                Vector3 knockback = (transform.position - other.transform.position).normalized;
				transform.position += knockback;
            }
        }
        */
    }
}
