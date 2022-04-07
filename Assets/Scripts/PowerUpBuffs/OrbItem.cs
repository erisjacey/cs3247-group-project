using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/OrbItem")]
public class OrbItem : PowerupEffect
{
    // Start is called before the first frame update
    public override void Apply(GameObject target){
    	if (target.tag == "Player") {
            FindObjectOfType<OrbCounter>().IncreaseCount();
    	}
    }
}
