using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/RangedAttackBuff")]
public class IncreaseRangedAttack : PowerupEffect
{
    // Start is called before the first frame update
    public int amount;
    public override void Apply(GameObject target){
    	if (target.tag == "Player") {
    		// HurtEnemy.damageToGive += amount;
    		target.GetComponent<PlayerController>().fireballDamage += amount;
    	}
    }
}