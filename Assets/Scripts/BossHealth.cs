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
    private Renderer renderer;
    private AudioManager audioManager;

     // Start is called before the first frame update
    void Start()
    {
       renderer = GetComponent<Renderer>();
       audioManager = FindObjectOfType<AudioManager>();
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        audioManager.Play("BossHurt");
        health -= damage;

        StartCoroutine(Flashing());

        if (health <= (rageThreshold * maxHealth) && !GetComponent<Animator>().GetBool("isEnraged"))
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
            audioManager.Play("BossRage");
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
        audioManager.Play("BossDie");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
