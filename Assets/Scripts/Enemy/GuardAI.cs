using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Pathfinding;

public class GuardAI : MonoBehaviour
{
	[SerializeField] private float maxRange;
	[SerializeField] private float minRange;

	private Transform player;
	private bool playerInRange = false;
	private Animator animator;
	private Rigidbody2D myRigidbody;
	private GuardPath path; 
	private float yOffset = 0.8f;

	void Start()
    {
		animator = GetComponentInChildren<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		myRigidbody = gameObject.GetComponentInChildren<Rigidbody2D>();
		path = gameObject.GetComponentInChildren<GuardPath>();
	}

	void Update()
	{	
		Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + yOffset, 0);
		if (Vector3.Distance(player.position, newPosition) <= maxRange && (Vector3.Distance(player.position, newPosition) > minRange))
		{
			playerInRange = true;
			animator.SetBool("playerInRange", true);
		}

		if (playerInRange)
		{
			FollowPlayer();
		}
		else
		{
			path.Patrol();
		}
	}

	void FollowPlayer()
	{	
		animator.SetFloat("moveX", player.position.x - transform.position.x);
		animator.SetFloat("moveY", player.position.y - transform.position.y - yOffset);
		path.SetPath();
	}

	public void Knockback(Vector3 knockback) {
		transform.position += knockback;
	}

}



