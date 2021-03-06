using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBossHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    private bool flashActive;

    [SerializeField] private float flashLength = 0f;
    [SerializeField] private float blinkLength = 0f;
    [SerializeField] GameObject chat;
    [SerializeField] private GameObject itemToDrop;

    private float flashCounter = 0f;
    private SpriteRenderer enemySprite;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemySprite = GetComponentInChildren<SpriteRenderer>();
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

    public void HurtFakeBoss(int damageToGive)
    {
        currentHealth -= damageToGive;

        flashActive = true;
        flashCounter = flashLength;

        if (currentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("EnemyDie");
            chat.SetActive(true);
            DropItem();
            Destroy(gameObject);
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("EnemyHurt");
        }
    }

    private void DropItem() 
	{   
        if (itemToDrop != null) 
        {
            Instantiate(itemToDrop, transform.position, transform.rotation);
        }
	}





}
