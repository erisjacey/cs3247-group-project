using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField]
    public int health = 200;
    public int maxHealth = 200;
    public float rageThreshold = 0.5f;
    public bool isInvulnerable = false;

    public bool isDead = false;
    private Renderer bossRenderer;

     // Start is called before the first frame update
    void Start()
    {
       bossRenderer = GetComponent<Renderer>();
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        //audioManager.Play("BossHurt");
        health -= damage;

        StartCoroutine(Flashing());

        if (health <= (rageThreshold * maxHealth) && !GetComponent<Animator>().GetBool("isEnraged"))
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
            FindObjectOfType<AudioManager>().Play("BossRage");
        }
        else if (health <= 0)
        {
            StartCoroutine(Die());
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("BossHurt");
        }
    }

    IEnumerator Flashing()
    {
        for (var n = 0; n < 2; n++)
        {
            bossRenderer.enabled = true;
            yield return new WaitForSeconds(.1f);
            bossRenderer.enabled = false;
            yield return new WaitForSeconds(.1f);
        }
        bossRenderer.enabled = true;
    }

    IEnumerator Die()
    {
        isDead = true;
        GetComponent<Animator>().Play("Death");
        FindObjectOfType<AudioManager>().Play("BossDie");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
