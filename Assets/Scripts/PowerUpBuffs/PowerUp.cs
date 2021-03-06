using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    public PowerupEffect powerupEffect;

    private void OnTriggerEnter2D(Collider2D collision){

        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            powerupEffect.Apply(collision.gameObject);
        }
    }
}
