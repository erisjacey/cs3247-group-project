using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int damageToGive;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive);
            Destroy(gameObject);
        } else if (other.tag != "Enemy" && other.tag == "Walls") {
            Destroy(gameObject);
        }
    }
}
