using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardController : MonoBehaviour
{   
    public Transform[] patrolSpots;
    private int randomSpot;

    public float startWaitTime;

    private bool playerInRange = false;
    private float waitTime;
    private Animator animator;
    private Transform target;


    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
        randomSpot = Random.Range(0, patrolSpots.Length);
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && (Vector3.Distance(target.position, transform.position) > minRange))
        {   
            playerInRange = true;
        }

        if (playerInRange) {
            FollowPlayer();
        } else {
            Patrolling();
        }
        
    }

    public void FollowPlayer()
    {   
        animator.SetBool("playerInRange", true);
        animator.SetFloat("moveX", (target.position.x - transform.position.x));
        animator.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void Patrolling()
    {   
        Vector3 nextSpotPos = patrolSpots[randomSpot].position;
        if (Vector3.Distance(transform.position, nextSpotPos) > 0.2f) {
            animator.SetFloat("moveX", nextSpotPos.x - transform.position.x);
            animator.SetFloat("moveY", nextSpotPos.y - transform.position.y);
            transform.position = Vector3.MoveTowards(transform.position, nextSpotPos, speed * Time.deltaTime);
        } else {
            if (waitTime <= 0) {
                animator.SetBool("patrolling", true);
                randomSpot = Random.Range(0, patrolSpots.Length);
                waitTime = startWaitTime;
            } else {
                animator.SetBool("patrolling", false);
                waitTime -= Time.deltaTime;
            }
        }

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {   
        // to be replace with weapon
        if (other.gameObject.tag == "Player")
        {
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }

    /*public void GoHome()
    {
        animator.SetFloat("moveX", (origin.position.x - transform.position.x));
        animator.SetFloat("moveY", (origin.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, origin.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, origin.position) == 0)
        {
            animator.SetBool("isMoving", false);
        }
    }*/
}
