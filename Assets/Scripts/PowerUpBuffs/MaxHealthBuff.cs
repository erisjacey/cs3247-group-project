using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/MaxHealthBuff")]
public class MaxHealthBuff : PowerupEffect
{
    // Start is called before the first frame update
    public int amount;
    public override void Apply(GameObject target){
    	if (target.tag == "Player") {
    		FindObjectOfType<HealthManager>().maxHealth += amount;
    		FindObjectOfType<HealthManager>().currentHealth = FindObjectOfType<HealthManager>().maxHealth;
    	}
    }
}
