using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnim;

    [SerializeField] float walkSpeed = 5f;

    private float attackTime = 0.25f;
    private float attackCounter = 0.25f;
    private bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        myRB.velocity = new Vector2(horizontalInput, verticalInput) * walkSpeed;

        myAnim.SetFloat("moveX", horizontalInput);
        myAnim.SetFloat("moveY", verticalInput);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1
            || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }
        if(isAttacking)
        {   
            myRB.velocity = Vector2.zero;
            attackCounter-= Time.deltaTime;
            if(attackCounter <= 0 )
            {
                myAnim.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            attackCounter = attackTime;
            myAnim.SetBool("isAttacking",true);
            isAttacking = true;
	    if (Mathf.Abs(horizontalInput) == 1 || Mathf.Abs(verticalInput) == 1)
        {
	        myAnim.SetFloat("lastMoveX", horizontalInput);
            myAnim.SetFloat("lastMoveY", verticalInput);
        }

        }
    }

}
