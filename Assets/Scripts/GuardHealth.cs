using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    [SerializeField]
    private SpriteRenderer enemySprite;

    public void TakesDamage(int damageToGive)
    {   

        currentHealth -= damageToGive;
        if (currentHealth == 0)
        {
            gameObject.SetActive(false);
        }
       
    }
}
