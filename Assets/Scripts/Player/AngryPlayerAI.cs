using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AngryPlayerAI : MonoBehaviour
{
    // Directions of projectiles
    private Vector3 left_up = Vector3.left + Vector3.up;
    private Vector3 right_down = Vector3.right + Vector3.down;
    private Vector3 left_down = Vector3.left + Vector3.down;
    private Vector3 right_up = Vector3.right + Vector3.up;
    private static Vector3[] directions1;
    private static Vector3[] directions2;
    
    

    [SerializeField]
    private float attackDelay;
    [SerializeField]
    private float attackTime;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;
    [SerializeField]
    private GameObject flame;

    private float yOffset = 1.95f;
    private Vector3 flameLastSpawn;
    private Transform player;
    private bool playerInRange = false;
    private Animator animator;
    private bool hasAttacked = false;
    private float lastAttackTime;
    private GuardPath path;

    void Start()
    {
		animator = GetComponentInChildren<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		path = gameObject.GetComponentInChildren<GuardPath>();
        directions1 = new Vector3[] {Vector3.left, Vector3.up, 1.25f * Vector3.right, Vector3.down, left_up,
        right_down, left_down, right_up};
        directions2 = new Vector3[] {Vector3.left / 2 + Vector3.up, Vector3.left + Vector3.up / 2,
        Vector3.left / 2 + Vector3.down, Vector3.left + Vector3.down / 2, Vector3.right / 2 + Vector3.up, Vector3.right + Vector3.up / 2,
        Vector3.right / 2 + Vector3.down , Vector3.right + Vector3.down / 2};
        flameLastSpawn = new Vector3(transform.position.x, transform.position.y + yOffset, 0);
        
	}

    // Update is called once per frame
    void Update()
    {   

        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + yOffset, 0);
        if (Vector3.Distance(player.position, newPosition) <= maxRange && (Vector3.Distance(player.position, newPosition) > minRange))
        {
            playerInRange = true;
            animator.SetBool("playerInRange", true);       
        }

        if (Vector3.Distance(flameLastSpawn, newPosition) >= 0.95f) {
            GameObject trail = Instantiate(flame, newPosition, transform.rotation);
            flameLastSpawn = newPosition;
        }


        if (hasAttacked) { 
            attackDelay -= Time.deltaTime;
            if (attackDelay <= 0) {
                hasAttacked = false;
                attackDelay = attackTime;
            }
        }

        if (playerInRange)
        {   
            float distanceToPlayer = Vector3.Distance(newPosition, player.position);
            if (distanceToPlayer < attackRange && !hasAttacked) {
                StartCoroutine(Attack());
            } else {
                FollowPlayer();
            }
        }
    }

    void FollowPlayer()
    {
		animator.SetFloat("moveX",  player.position.x - transform.position.x);
		animator.SetFloat("moveY", player.position.y - (transform.position.y + yOffset));
        path.SetPath();
    }

    void RageAttack()
    {   

        
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
		animator.SetFloat("moveY", path.GetAIVelocity().y);
        path.DisableMove();
        animator.SetBool("isAttacking", true);
        hasAttacked = true;
        yield return new WaitForSeconds(0.65f);
        animator.SetBool("isAttacking", false);
        path.EnableMove();
    }
}
