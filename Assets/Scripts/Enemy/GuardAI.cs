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

	void Start()
    {
		animator = GetComponentInChildren<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		myRigidbody = gameObject.GetComponentInChildren<Rigidbody2D>();
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
		animator.SetFloat("moveY", player.position.y - transform.position.y);
		path.SetPath();
	}


	private void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "MyWeapon")
		{	
			Vector3 knockback = (transform.position - other.transform.position).normalized / 1.2f;
			transform.position += knockback;
		} else if (other.tag == "Player") {
			Vector3 knockback = (transform.position - other.transform.position).normalized;
			transform.position += knockback;
		}
	}
}



