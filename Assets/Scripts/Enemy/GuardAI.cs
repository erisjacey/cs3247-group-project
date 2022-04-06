using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace Pathfinding
{
	public class GuardAI : VersionedMonoBehaviour
	{
		/// <summary>Target points to move to in order</summary>
		public Transform[] targets;
		private Transform player;
		public bool isStationary;
		/// <summary>Time in seconds to wait at each target</summary>
		public float delay = 0;

		/// <summary>Current target index</summary>
		int index;

		IAstarAI agent;
		float switchTime = float.PositiveInfinity;
		bool playerInRange = false;
		Animator animator;
		[SerializeField] private float maxRange;
		[SerializeField] private float minRange;
		private Rigidbody2D myRigidbody;

		protected override void Awake()
		{
			base.Awake();
			agent = GetComponent<IAstarAI>();
			index = Random.Range(0, targets.Length);
			animator = GetComponentInChildren<Animator>();
			player = GameObject.FindGameObjectWithTag("Player").transform;
			myRigidbody = gameObject.GetComponent<Rigidbody2D>();
		}

		/// <summary>Update is called once per frame</summary>
		void Update()
		{
			if (Vector3.Distance(player.position, agent.position) <= maxRange && (Vector3.Distance(player.position, agent.position) > minRange))
			{
				playerInRange = true;
			}

			if (playerInRange)
			{
				FollowPlayer();
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

		void OnCollisionEnter2D(Collision2D other)
		{
			Debug.Log("hit detected");
			// to be replace with weapon
			if (other.gameObject.tag == "Player")
			{
				
				Vector3 knockback = (transform.position - other.transform.position).normalized;
				transform.position += knockback;
				
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "MyWeapon")
			{
				
				Vector3 knockback = (transform.position - other.transform.position).normalized;
				transform.position += knockback;
			}
		}
	}


}
