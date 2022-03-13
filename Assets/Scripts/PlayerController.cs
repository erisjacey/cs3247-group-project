using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnim;

    [SerializeField] float walkSpeed = 5f;

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
    }
}
