using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    private bool flashActive;
    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    [SerializeField]
    private float blinkLength = 0f;
    private SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
	playerSprite = GetComponent<SpriteRenderer>();        
    }

    // Update is called once per frame
    void Update()
    {
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
        currentHealth -= damageToGive;
	flashActive = true;
        flashCounter = flashLength;

        if (currentHealth <= 0)
        {
	    gameObject.SetActive(false);
	}
    }
}
