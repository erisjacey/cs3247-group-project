using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnim;

    [SerializeField] public float walkSpeed = 5f;

    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttacking;
    private int numKeys;

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

	    if (Mathf.Abs(horizontalInput) == 1 || Mathf.Abs(verticalInput) == 1)
        {
	        myAnim.SetFloat("lastMoveX", horizontalInput);
            myAnim.SetFloat("lastMoveY", verticalInput);
        }

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackCounter = attackTime;
            myAnim.SetBool("isAttacking", true);
            isAttacking = true;
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
