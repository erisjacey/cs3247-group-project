using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField]
    private int damageToGive = 10;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive);
        }
    }
}
