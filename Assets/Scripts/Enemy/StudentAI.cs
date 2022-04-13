using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;

public class StudentAI : MonoBehaviour
{   	
	[SerializeField]
	private float attackDelay;
	[SerializeField]
	private float attackRange;
	[SerializeField]
	private float maxRange;
	[SerializeField]
	private float minRange;
	[SerializeField]
	private float projectileForce;
	[SerializeField]
	private GameObject projectile;

	private GuardPath path;
	private float lastAttackTime = 0;
	private bool playerInRange = false;
	private Animator animator;
	private Transform player;

	void Start()
    {
		animator = GetComponentInChildren<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		path = gameObject.GetComponentInChildren<GuardPath>();
	}

	void Update()
	{
		if (Vector3.Distance(player.position, transform.position) <= maxRange && (Vector3.Distance(player.position, transform.position) > minRange))
		{
			playerInRange = true;
			animator.SetBool("playerInRange", true);
		}

		if (playerInRange)
		{   
			float distanceToPlayer = Vector3.Distance(transform.position, player.position);
			if (distanceToPlayer < attackRange) {
				RangeAttack();
			} else {
				FollowPlayer();
			}
		}
		else
		{
			path.Patrol();
		}
	}

	void FollowPlayer()
	{
		animator.SetFloat("moveX",  player.position.x - transform.position.x);
		animator.SetFloat("moveY", player.position.y - transform.position.y);
		path.SetPath();
	}

	void RangeAttack()
	{   
		Vector3 playerDirection = (player.position - transform.position).normalized;
		if (Time.time > lastAttackTime + attackDelay) {
			GameObject word = Instantiate (projectile, transform.position, transform.rotation);
			word.GetComponent<Rigidbody2D>().AddForce(playerDirection * projectileForce);
			lastAttackTime = Time.time;
			FollowPlayer();
		} else {
			FollowPlayer();
		}
	}

	public void Knockback(Vector3 knockback) {
		transform.position += knockback;
	}
}


