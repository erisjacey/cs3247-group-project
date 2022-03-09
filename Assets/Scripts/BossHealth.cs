using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField]
    public int health = 250;
    public bool isInvulnerable = false;

    public bool isDead = false;

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;

        if (health <= 200)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }

        if (health <= 0)
            StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        isDead = true;
        GetComponent<Animator>().Play("Death");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
