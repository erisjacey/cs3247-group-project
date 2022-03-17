using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField]
    public int health = 250;
    public bool isInvulnerable = false;

    public bool isDead = false;
    private Renderer renderer;

     // Start is called before the first frame update
    void Start()
    {
       renderer = GetComponent<Renderer>();
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;

        StartCoroutine(Flashing());

        if (health <= 200)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }

        if (health <= 0)
            StartCoroutine(Die());
    }

    IEnumerator Flashing()
    {
        for (var n = 0; n < 2; n++)
        {
            renderer.enabled = true;
            yield return new WaitForSeconds(.1f);
            renderer.enabled = false;
            yield return new WaitForSeconds(.1f);
        }
        renderer.enabled = true;
    }

    IEnumerator Die()
    {
        isDead = true;
        GetComponent<Animator>().Play("Death");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
