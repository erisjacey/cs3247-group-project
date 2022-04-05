using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D myRB;
    public Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myRB.velocity = transform.right * speed;   
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
	if (other.tag != "Player")
	{
            Debug.Log("Fireball hit");
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
