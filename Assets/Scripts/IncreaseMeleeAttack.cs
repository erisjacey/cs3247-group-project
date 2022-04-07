using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/MeleeAttackBuff")]
public class IncreaseMeleeAttack: PowerupEffect
{
    // Start is called before the first frame update
    public int amount;
    public override void Apply(GameObject target){
    	if (target.tag == "Player") {
    		target.GetComponent<PlayerController>().swordDamage += amount;
            // HurtEnemy.damageToGive += amount;
            FindObjectOfType<PlayerStatsManager>().swordDamage += amount;
    	}
    }
}
