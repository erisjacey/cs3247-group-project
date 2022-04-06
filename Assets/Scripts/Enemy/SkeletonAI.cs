using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;

public class SkeletonAI : MonoBehaviour
{
    [SerializeField]
    private float attackDelay;
    [SerializeField]
    private float attackTime;
    [SerializeField]
    public float attackRange;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;

    private Transform player;
    private GuardPath path;
    private bool playerInRange = false;
    private Animator animator;
    private float lastAttackTime;
    private bool hasAttacked = false;

    void Start()
    {   
		animator = GetComponentInChildren<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		path = gameObject.GetComponentInChildren<GuardPath>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= maxRange && (Vector3.Distance(player.position, transform.position) > minRange))
        {
            playerInRange = true;
            animator.SetBool("playerInRange", true);
        }

        if (hasAttacked)
        {
            attackDelay -= Time.deltaTime;
            if (attackDelay <= 0)
            {
                attackDelay = attackTime;
                hasAttacked = false;
            }
        }

        if (playerInRange)
        {   
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer < attackRange && !hasAttacked) {
                StartCoroutine(Attack());
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

    
    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "MyWeapon")
        {   
            Vector3 knockback = (transform.position - other.transform.position).normalized / 3.5f;
            transform.position += knockback;
        }
    }

    IEnumerator Attack()
    {   
        animator.SetFloat("moveX",  player.position.x - transform.position.x);
		animator.SetFloat("moveY", player.position.y - transform.position.y);
        path.DisableMove();
        animator.SetBool("isAttacking", true);
        hasAttacked = true;
        yield return new WaitForSeconds(0.65f);
        animator.SetBool("isAttacking", false);
        path.EnableMove();
    }
    
}

