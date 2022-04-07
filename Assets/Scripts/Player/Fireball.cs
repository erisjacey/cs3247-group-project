using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float lifetime;
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
        if (lifetime <= 0.0f)
        {
            DestroySelf();
        }
        lifetime -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
	if (other.tag != "Player" && !other.isTrigger)
	{
            Debug.Log("Fireball hit");
            DestroySelf();
	} 
    }

    public IEnumerator DestroyGameObjectAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    private void DestroySelf()
    {
        myAnim.SetTrigger("hit");
        myRB.velocity = Vector2.zero;
        StartCoroutine(DestroyGameObjectAfter(0.2f));
    }
}
