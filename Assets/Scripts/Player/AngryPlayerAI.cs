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
    [SerializeField]
    private GameObject explosion;
    

    private float yOffset = 0.4f;
    private Vector3 flameLastSpawn;
    private Transform player;
    private bool playerInRange = false;
    private Animator animator;
    private bool hasAttacked = false;
    private float lastAttackTime;
    private GuardPath path;
    private AngryPlayerHealth health;

    private int explosionTimes = 30;
    private float rageAttackDelay = 0.15f;
    private float lastExplosion = 0f;

    void Start()
    {
		animator = GetComponentInChildren<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		path = gameObject.GetComponentInChildren<GuardPath>();
        flameLastSpawn = new Vector3(transform.position.x, transform.position.y + yOffset, 0);
        health = gameObject.GetComponentInChildren<AngryPlayerHealth>();
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

        if (animator.GetBool("isEnraged")) {
            path.DisableMove();
            if (lastExplosion + rageAttackDelay < Time.time) {
                if (explosionTimes > 0) {
                    RageAttack();
                    explosionTimes -= 1;
                } else {
                    explosionTimes = 30;
                    path.EnableMove();
                    animator.SetBool("isEnraged", false);
                    animator.Play("Move");
                    health.DisableInvulverable();
                }
            } 
            return;
        }

        if (Vector3.Distance(flameLastSpawn, newPosition) >= 1f) {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 1.45f, 0);
            GameObject trail = Instantiate(flame, spawnPosition, transform.rotation);
            flameLastSpawn = newPosition;
        }


        if (hasAttacked) { 
            attackDelay -= Time.deltaTime;
            if (attackDelay <= 0) {
                hasAttacked = false;
                attackDelay = attackTime;
                animator.Play("Move");
                path.EnableMove();
            } else {
                return;
            }
        }

        if (playerInRange)
        {   
            float distanceToPlayer = Vector3.Distance(newPosition, player.position);
            if (distanceToPlayer < attackRange && !hasAttacked) {
                Attack();
            } else {
                FollowPlayer();
            }
        }
    }

    void FollowPlayer()
    {
		animator.SetFloat("moveX",  player.position.x - transform.position.x);
		animator.SetFloat("moveY", player.position.y - (transform.position.y - yOffset));
        path.SetPath();
    }


    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "MyWeapon")
        {   
            Vector3 knockback = (transform.position - other.transform.position).normalized / 3.5f;
            transform.position += knockback;
        }
    }

    void RageAttack()
    {   
        GameObject attack = Instantiate(explosion, player.position, player.rotation);
        lastExplosion = Time.time;
    }

    void Attack()
    {   
        hasAttacked = true;
        animator.Play("Attack");
        path.DisableMove();
    }
}
