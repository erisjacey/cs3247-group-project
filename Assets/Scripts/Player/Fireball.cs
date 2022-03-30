using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myRB;
    public Animator myAnim;
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GameObject.Find("Player").GetComponent<Animator>();
        myAnim.SetFloat("moveX", playerAnim.GetFloat("lastMoveX"));
        myAnim.SetFloat("moveY", playerAnim.GetFloat("lastMoveY"));
        myRB.velocity = new Vector2(myAnim.GetFloat("moveX"), myAnim.GetFloat("moveY")) * speed; 
        //myRB.velocity = transform.up * speed;   
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(transform.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
	if (other.tag != "Player")
	{
            Debug.Log("Fireball hit");
            //gameObject.SetActive(false);
            myAnim.SetTrigger("hit");
            myRB.velocity = Vector2.zero;
            StartCoroutine(DestroyGameObjectAfter(0.2f));
	} 
    }

    public IEnumerator DestroyGameObjectAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
