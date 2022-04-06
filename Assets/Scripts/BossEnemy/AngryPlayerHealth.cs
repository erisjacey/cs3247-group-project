using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryPlayerHealth : MonoBehaviour
{
    [SerializeField]
    public int health;
    public int maxHealth;
    public float rageThreshold = 0.5f;
    public bool isInvulnerable = false;

    public bool isDead = false;
    private Renderer bossRenderer;
    private Animator animator;
    private float lastRageTime = 0f;
    private float rageAttackCoolDown = 20f;

     // Start is called before the first frame update
    void Start()
    {
       bossRenderer = GetComponentInChildren<Renderer>();
       animator = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        //audioManager.Play("BossHurt");
        health -= damage;

        StartCoroutine(Flashing());

        if (health <= (rageThreshold * maxHealth) && !animator.GetBool("isEnraged"))
        {   
            if (lastRageTime == 0f || (lastRageTime + rageAttackCoolDown < Time.time)) {
                animator.SetBool("isEnraged", true);
                animator.Play("special_attack");
                FindObjectOfType<AudioManager>().Play("BossRage");
            }
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
        animator.Play("Death");
        FindObjectOfType<AudioManager>().Play("BossDie");
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
