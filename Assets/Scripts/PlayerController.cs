using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Rigidbody2D myRB;
    private Animator myAnim;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        myRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;

        myAnim.SetFloat("moveX", myRB.velocity.x);
        myAnim.SetFloat("moveY", myRB.velocity.y);

	if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1
           || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
	    myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }


    public IEnumerator KnockBack(float duration, float thrust, Transform obj)
    {
        float timer = 0;
        while (duration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            myRB.AddForce(-direction * thrust);
        }
        yield return 0;
    }

}
