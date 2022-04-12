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
    private float rageAttackCoolDown = 12f;
    private Collider2D Collider2D;

     // Start is called before the first frame update
    void Start()
    {
       bossRenderer = GetComponentInChildren<Renderer>();
       animator = GetComponentInChildren<Animator>();
       Collider2D = GetComponentInChildren<Collider2D>();
    }

    public void TakeDamage(int damage)
    {   
        if (isInvulnerable)
            return;

        //audioManager.Play("BossHurt");
        health -= damage;

        StartCoroutine(Flashing());

        if (health <= (rageThreshold * maxHealth) && !animator.GetBool("isEnraged") && (lastRageTime == 0f || lastRageTime + rageAttackCoolDown <= Time.time))
        {        
            animator.SetBool("isEnraged", true);
            animator.Play("special_attack");
            FindObjectOfType<AudioManager>().Play("BossRage");
            lastRageTime = Time.time;
            isInvulnerable = true;
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

    public void DisableInvulverable() {
        isInvulnerable = false;
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

        FindObjectOfType<StateManager>().LoadNextLevel();
    }
}
