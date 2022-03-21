using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    private HealthBar healthBar;
    private bool flashActive;
    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    [SerializeField]
    private float blinkLength = 0f;

    private GameObject player;
    private SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<HealthBar>();
        player = FindObjectOfType<PlayerController>().gameObject;
	    playerSprite = player.GetComponent<SpriteRenderer>();     

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);   
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
	    playerSprite = player.GetComponent<SpriteRenderer>();     

        if (flashActive)
        {
            if ((int)(100 * flashCounter / blinkLength) % 2 == 0)
            {
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }

            if (flashCounter <= 0)
            {
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        FindObjectOfType<AudioManager>().Play("PlayerHurt");
        currentHealth -= damageToGive;
        healthBar.SetHealth(currentHealth);

	    flashActive = true;
        flashCounter = flashLength;

        if (currentHealth <= 0)
        {
            PlayerDie();
	    }
    }

    private void PlayerDie()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
	    playerSprite = player.GetComponent<SpriteRenderer>();  

        LevelManager.instance.GameOver();
        player.SetActive(false);
    }
}
