using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    //private float counter = 0;
    //private float tickInterval = 1;

    public Transform homePos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float enragedSpeed;
    [SerializeField]
    private float maxRange;    
    [SerializeField]
    private float minRange;

    public int attackDamage = 20;
    public int enragedAttackDamage = 40;

    public Vector3 attackOffset;
    public LayerMask attackMask;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
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
                else if (Vector3.Distance(target.position, transform.position) > maxRange)
                {
                    GoHome();
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
    }
    public void EnragedFollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, enragedSpeed * Time.deltaTime);
    }

    public void AttackPlayer()
    {
        //myAnim.SetBool("isWithinRange", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));

        float faceUp = myAnim.GetFloat("moveY") / Mathf.Abs(myAnim.GetFloat("moveY"));
        float faceRight = myAnim.GetFloat("moveX") / Mathf.Abs(myAnim.GetFloat("moveX"));

        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x * faceRight;
        pos += transform.up * attackOffset.y * faceUp;

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

        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x * faceRight;
        pos += transform.up * attackOffset.y * faceUp;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, minRange, attackMask);
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
