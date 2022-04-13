using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    
    [SerializeField] private float flashLength = 0f;
    [SerializeField] private float blinkLength = 0f;
    [SerializeField] private GameObject itemToDrop;

    private bool flashActive;
    private float flashCounter = 0f;
    private SpriteRenderer enemySprite;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
	    enemySprite = GetComponentInChildren<SpriteRenderer>();  
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flashActive)
        {
            if ((int)(100 * flashCounter / blinkLength) % 2 == 0)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }

            if (flashCounter <= 0)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
                flashActive = false;
            }
                flashCounter -= Time.deltaTime;
        }
    }

    public void HurtEnemy(int damageToGive)
    {   
        
        FindObjectOfType<AudioManager>().Play("EnemyHurt");
        StartCoroutine(Hurt());
        currentHealth -= damageToGive;

	    flashActive = true;
        flashCounter = flashLength;

        if (currentHealth <= 0)
        {   
            GetComponentInChildren<Collider2D>().enabled = false;
            animator.Play("Death");
            DropItem();
            Destroy(gameObject, 0.15f);
	    }
    }

    private void DropItem() 
	{   
        if (itemToDrop != null) 
        {
            Instantiate(itemToDrop, transform.position, transform.rotation);
        }
		
	}

    
    IEnumerator Hurt()
    {   
        animator.SetBool("isHurting", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("isHurting", false);
    }

}
