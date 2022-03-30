using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pathfinding
{   
    public class StudentAI : VersionedMonoBehaviour
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
        public float attackDelay;
        public float attackRange;
		[SerializeField]
		private float maxRange;
		[SerializeField]
		private float minRange;

        public GameObject projectile;
        public float projectileForce;

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

			if (playerInRange)
			{   
                float distanceToPlayer = Vector3.Distance(agent.position, player.position);
                if (distanceToPlayer < attackRange) {
                    RangeAttack();
                } else {
                    FollowPlayer();
                }
			}
			else
			{
				if (isStationary)
				{
					animator.SetBool("patrolling", false);
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

        void RangeAttack()
        {   
            Vector3 playerDirection = player.position - transform.position;
            if (Time.time > lastAttackTime + attackDelay) {
                GameObject word = Instantiate (projectile, transform.position, transform.rotation);
                word.GetComponent<Rigidbody2D>().AddForce(playerDirection * projectileForce);
                lastAttackTime = Time.time;
                FollowPlayer();
            } else {
                FollowPlayer();
            }
            /*
            
            float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            */
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
				animator.SetBool("isPatrolling", true);
			}

			agent.destination = targets[index].position;
			animator.SetFloat("moveX", targets[index].position.x - agent.position.x);
			animator.SetFloat("moveY", targets[index].position.y - agent.position.y);
			if (search) agent.SearchPath();
		}

        void OnCollisionEnter2D(Collision2D other)
		{
			Debug.Log("hit detected");
			// to be replace with weapon
			if (other.gameObject.tag == "Player")
			{
				Vector2 difference = transform.position - other.transform.position;
				transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
			}
		}

		private void OnTriggerEnter2D(Collider2D other){
			if (other.tag == "MyWeapon")
			{
				
				Vector2 difference = transform.position - other.transform.position;
				transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
				
			}
		}
    }


}