using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class SpeedBuff : PowerupEffect
{
    // Start is called before the first frame update
    public float amount;

    public override void Apply(GameObject target) {
    	if (target.tag == "Player") {
    		FindObjectOfType<PlayerController>().walkSpeed += amount;
    	}
    }
}
