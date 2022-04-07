using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/BossKeyItem")]
public class BossKeyItem : PowerupEffect
{
    // Start is called before the first frame update
    public override void Apply(GameObject target){
    	if (target.tag == "Player") {
            FindObjectOfType<KeyManager>().AddBossKey();
    	}
    }
}
