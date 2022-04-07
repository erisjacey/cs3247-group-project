using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnim;

    private const float horizontalDistanceFromCentre = 0.53f;
    private const float verticalDistanceFromCentre = 0.74f;

    [SerializeField] public float walkSpeed = 5f;

    private int currentSkill;
    private const int SWORD = 0;
    private const int STAFF = 1;
    private const int SHIELD = 2;

    private bool isAttacking;

    // Sword
    private float attackTime = .25f;
    private float attackCounter = .25f;
    private int numKeys;

    // Staff
    public GameObject fireball;
    public Transform shotPoint;
    private float timeBetweenShots;
    private float startTimeBetweenShots = .4f;

    // Shield
    
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        currentSkill = getCurrentSkill();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        myRB.velocity = new Vector2(horizontalInput, verticalInput) * walkSpeed;

        myAnim.SetFloat("moveX", horizontalInput);
        myAnim.SetFloat("moveY", verticalInput);

        if (Mathf.Abs(horizontalInput) == 1 || Mathf.Abs(verticalInput) == 1)
        {
            myAnim.SetFloat("lastMoveX", horizontalInput);
            myAnim.SetFloat("lastMoveY", verticalInput);
            shotPoint.transform.localPosition = new Vector3(horizontalInput * horizontalDistanceFromCentre, verticalInput * verticalDistanceFromCentre - 0.12f, 0.0f);
            float angle = Mathf.Rad2Deg * Mathf.Atan2(verticalInput, horizontalInput);
            shotPoint.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
        }

        if (!isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                changeCurrentSkill(SWORD);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                changeCurrentSkill(STAFF);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                changeCurrentSkill(SHIELD);
            }
        }

        switch (currentSkill)
        {
            case SWORD:
                Sword();
                break;
            case STAFF:
                Staff();
                break;
            case SHIELD:
                Shield();
                break;
            default:
                break;
         }
    }

    private void changeCurrentSkill(int skill)
    {
        if (currentSkill != skill)
        {
            if (FindObjectOfType<SkillManager>().SetActiveSkill(skill))
            {
                currentSkill = skill;
                myAnim.SetFloat("currentSkill", (float)skill);
            }
        }
    }

    private int getCurrentSkill()
    {
        int skill = FindObjectOfType<SkillManager>().GetActiveSkill();
        myAnim.SetFloat("currentSkill", (float)skill);
        return skill;
    }

    void Sword()
    {
        if (isAttacking)
        {
            myRB.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                myAnim.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            attackCounter = attackTime;
            myAnim.SetBool("isAttacking", true);
            isAttacking = true;
        }
    }

    void Staff()
    {    
        if (timeBetweenShots <= 0)
        {
            myAnim.SetBool("isAttacking", false);
            isAttacking = false; 
            if (Input.GetKeyDown(KeyCode.Space))
            {  
                myAnim.SetBool("isAttacking", true);
                isAttacking = true;
                Instantiate(fireball, shotPoint.position, shotPoint.rotation);
                timeBetweenShots = startTimeBetweenShots;
            }
        }
        else
        {
            myRB.velocity = Vector2.zero;
            timeBetweenShots -= Time.deltaTime;
        }
    }

    void Shield()
    {
        if (isAttacking)
        {
            if (!Input.GetKey(KeyCode.Space))
            {
                FindObjectOfType<HealthManager>().LoseInvulnerability();
                myAnim.SetBool("isAttacking", false);
                isAttacking = false;
                walkSpeed *= 10;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<HealthManager>().BecomeInvulnerable(false);
            attackCounter = attackTime;
            myAnim.SetBool("isAttacking", true);
            isAttacking = true;
            walkSpeed /= 10;
        }
    }

    public int GetNumKeys() 
    {
        return numKeys;
    }

    public void AddKey() 
    {
        numKeys += 1;
    }

    public void UseKeys(int keysUsed) 
    {
        numKeys -= keysUsed;
    }
}
