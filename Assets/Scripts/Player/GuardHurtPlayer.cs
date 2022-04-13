using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardHurtPlayer : MonoBehaviour
{
    [SerializeField]
    private int damageToGive = 10;


    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive);
        }
    }
}
