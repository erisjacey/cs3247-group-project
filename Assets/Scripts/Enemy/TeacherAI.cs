using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TeacherAI : MonoBehaviour
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
    private GameObject projectile;
    [SerializeField]
    private GameObject[] insults;
    [SerializeField]
    private float projectileForce;

    private Transform player;
    private bool playerInRange = false;
    private Animator animator;
    private bool isRangeAttack = false;
    private float lastAttackTime;
    private GuardPath path;
    private float yOffset = 1.95f;
    private int numberOfAttack = 1;

    private float lastRageAttackTime = 0f;
    private float rageAttackDelay = 2.5f;

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
        
	}

    // Update is called once per frame
    void Update()
    {   
        if (Vector3.Distance(player.position, transform.position) <= maxRange && (Vector3.Distance(player.position, transform.position) > minRange))
        {
            playerInRange = true;
            animator.SetBool("playerInRange", true);
        }

        if (animator.GetBool("isEnraged")) {
            path.DisableMove();
            if (lastRageAttackTime + rageAttackDelay <= Time.time) {
                RageAttack();
            }

            return;
        }

        if (isRangeAttack) { 
            attackDelay -= Time.deltaTime;
            if (attackDelay <= 0) {
                isRangeAttack = false;
                attackDelay = attackTime;
            }
            return;
        }

        if (playerInRange)
        {   
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer < attackRange) {
                path.DisableMove();
                RangeAttack();
            } else {
                animator.SetBool("isRangeAttack", false);
                path.EnableMove();
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
        bool isDir1 = true;
        for (int i = 0; i <= 3; i++) {
            int curDir = 0;
            foreach (GameObject g in insults) {
                if (curDir == 8) {
                    curDir = 0;
                }
                Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + yOffset, 0);
                GameObject projectile = Instantiate(g, newPosition, transform.rotation);
                if (isDir1) {
                    projectile.GetComponent<Rigidbody2D>().AddForce(directions1[curDir] * 700);
                } else {
                    projectile.GetComponent<Rigidbody2D>().AddForce(directions2[curDir] * 700);
                }
                isDir1 = !isDir1;
                curDir++;
            }
        }
        lastRageAttackTime = Time.time;
    }

    void RangeAttack()
    {   
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + yOffset, 0);
        if (Time.time > lastAttackTime + attackDelay) {
            
            Vector3 playerDirection = (player.position - newPosition).normalized;
            animator.SetFloat("moveX", player.position.x - transform.position.x);
            animator.SetFloat("moveY", player.position.y - (transform.position.y + yOffset));
            animator.SetBool("isRangeAttack", true);
            isRangeAttack = true;
            
            if (numberOfAttack % 3 == 0) {
                Vector3 newDirection1;
                Vector3 newDirection2;
                if (Mathf.Abs(playerDirection.x) > Mathf.Abs(playerDirection.y)) {
                    newDirection1 = new Vector3(playerDirection.x, playerDirection.y - 0.3f, 0).normalized;
                    newDirection2 = new Vector3(playerDirection.x, playerDirection.y + 0.3f, 0).normalized;
                } else {
                    newDirection1 = new Vector3(playerDirection.x - 0.3f, playerDirection.y, 0).normalized;
                    newDirection2 = new Vector3(playerDirection.x + 0.3f, playerDirection.y, 0).normalized;
                }
                
                GameObject book = Instantiate (projectile, newPosition, transform.rotation);
                GameObject book1 = Instantiate (projectile, newPosition, transform.rotation);
                GameObject book2 = Instantiate (projectile, newPosition, transform.rotation);
                book.GetComponent<Rigidbody2D>().AddForce(playerDirection * projectileForce);
                book1.GetComponent<Rigidbody2D>().AddForce(newDirection1 * projectileForce);
                book2.GetComponent<Rigidbody2D>().AddForce(newDirection2 * projectileForce);
            } else {
                GameObject book = Instantiate (projectile, newPosition, transform.rotation);
                book.GetComponent<Rigidbody2D>().AddForce(playerDirection * projectileForce);
            }
            numberOfAttack++;
            lastAttackTime = Time.time;
        } else {
            FollowPlayer();
        }
    }


}

