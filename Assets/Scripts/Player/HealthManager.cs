using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    private HealthBar healthBar;
    private bool flashActive;
    private bool isInvulnerable;
    
    [SerializeField] private float flashLength = 0f;
    private float flashCounter = 0f;
    [SerializeField] private float blinkLength = 0f;

    private GameObject player;
    private SpriteRenderer playerSprite;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isInvulnerable = false;
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene.Contains("Shop_Creation")) ResetHealth();
    }

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
        if (FindObjectsOfType<PlayerController>().Length <= 0) return;

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
                LoseInvulnerability();
            }
            flashCounter -= Time.deltaTime;
        }

        healthBar.SetHealth(currentHealth);
    }

    public void HurtPlayer(int damageToGive)
    {
        if (isInvulnerable) return;

        BecomeInvulnerable(true);
        FindObjectOfType<AudioManager>().Play("PlayerHurt");
        currentHealth -= damageToGive;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            PlayerDie();
        }
    }

    public void BecomeInvulnerable(bool flash)
    {
        flashActive = flash;
        flashCounter = flashLength;
        isInvulnerable = true;
    }

    public void LoseInvulnerability()
    {
        flashActive = false;
        isInvulnerable = false;
    }

    private void PlayerDie()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
	    playerSprite = player.GetComponent<SpriteRenderer>();  

        FindObjectOfType<LevelManager>().GameOver();
        FindObjectOfType<AudioManager>().Play("PlayerDie");
        player.SetActive(false);
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void IncreaseMaxHealth(int increaseAmt)
    {
        maxHealth += increaseAmt;
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
}
