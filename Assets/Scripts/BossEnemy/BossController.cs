using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    //private float counter = 0;
    //private float tickInterval = 1;

    [SerializeField] private float speed;
    [SerializeField] private float enragedSpeed;
    [SerializeField] private float maxRange;    
    [SerializeField] private float minRange;

    public int attackDamage = 20;
    public int enragedAttackDamage = 40;

    public Transform homePos;
    public Vector3 attackOffset;
    public LayerMask attackMask;
    private Transform player;
    private GuardPath path; 

    // Start is called before the first frame update
    void Start()
    {   
        player = GameObject.FindGameObjectWithTag("Player").transform;
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
        path = gameObject.GetComponentInChildren<GuardPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<BossHealth>().isDead)
        {
            return;
        }

        //if (counter < tickInterval)
        //{
        //    counter += Time.deltaTime;
        //}
        //else
        //{
        //    GetComponent<BossHealth>().TakeDamage(10);
        //    counter = 0;
        //}
        myAnim.SetBool("isWithinRange", false);

        if (!myAnim.GetBool("isEnraging"))
        {
            if (myAnim.GetBool("isEnraged"))
            {
                if (Vector3.Distance(target.position, transform.position) >= minRange)
                {
                    EnragedFollowPlayer();
                }
                else
                {
                    myAnim.SetBool("isWithinRange", true); // attack player
                }
            }
            else
            {
                if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
                {
                    FollowPlayer();
                }
                else if (Vector3.Distance(target.position, transform.position) < minRange)
                {
                    myAnim.SetBool("isWithinRange", true); // attack player
                }
            }
        }
    }

    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        path.SetPath();
    }
    public void EnragedFollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        path.IncreaseVelocity(0.5f);
        path.SetPath();
    }

    public void AttackPlayer()
    {
        //myAnim.SetBool("isWithinRange", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));

        float faceUp = myAnim.GetFloat("moveY") / Mathf.Abs(myAnim.GetFloat("moveY"));
        float faceRight = myAnim.GetFloat("moveX") / Mathf.Abs(myAnim.GetFloat("moveX"));

        Vector3 pos = transform.position;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, minRange, attackMask);
        if (colInfo != null && colInfo.tag == "Player")
        {
            FindObjectOfType<HealthManager>().HurtPlayer(attackDamage);
        }
    }
    
    public void EnragedAttackPlayer()
    {
        //myAnim.SetBool("isWithinRange", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));

        float faceUp = myAnim.GetFloat("moveY") / Mathf.Abs(myAnim.GetFloat("moveY"));
        float faceRight = myAnim.GetFloat("moveX") / Mathf.Abs(myAnim.GetFloat("moveX"));

        Collider2D colInfo = Physics2D.OverlapCircle(transform.position, minRange, attackMask);
        if (colInfo != null && colInfo.tag == "Player")
        {
            FindObjectOfType<HealthManager>().HurtPlayer(enragedAttackDamage);
        }
    }

    
    public void GoHome()
    {
        myAnim.SetFloat("moveX", (homePos.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);

        if (Vector3.Distance(homePos.position, transform.position) == 0)
        {
            myAnim.SetBool("isMoving", false);
        }
    }

}
