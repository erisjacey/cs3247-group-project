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
            attackDelay -= Time.deltaTime;
            path.DisableMove();
            if (attackDelay <= 0) {
                RageAttack();
                attackDelay = attackTime;
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
        for (int i = 0; i < 2; i++) {
            int curDir = 0;
            foreach (GameObject g in insults) {
                if (curDir == 8) {
                    curDir = 0;
                }
                Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + yOffset, 0);
                GameObject projectile = Instantiate(g, newPosition, transform.rotation);
                if (isDir1) {
                    projectile.GetComponent<Rigidbody2D>().AddForce(directions1[curDir] * 650);
                } else {
                    projectile.GetComponent<Rigidbody2D>().AddForce(directions2[curDir] * 650);
                }
                isDir1 = !isDir1;
                curDir++;
            }
        }
        
    }

    void RangeAttack()
    {   
        if (Time.time > lastAttackTime + attackDelay) {
            Vector3 playerDirection = player.position - transform.position;
            animator.SetFloat("moveX", player.position.x - transform.position.x);
            animator.SetFloat("moveY", player.position.y - (transform.position.y + yOffset));
            animator.SetBool("isRangeAttack", true);
            isRangeAttack = true;
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + yOffset, 0);
            GameObject book = Instantiate (projectile, newPosition, transform.rotation);
            book.GetComponent<Rigidbody2D>().AddForce(playerDirection * projectileForce);
            lastAttackTime = Time.time;
        } else {
            FollowPlayer();
        }
    }


}

