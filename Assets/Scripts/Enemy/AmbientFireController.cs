using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientFireController : MonoBehaviour
{
    [SerializeField]
    private int damageToGive;
    Animator animator;

    private void Start()
    {
        float playbackSpeed = Random.Range(0.5f, 1.0f);
        animator = gameObject.GetComponent<Animator>();
        animator.speed = playbackSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (other.gameObject.GetComponent<PlayerController>().isAmbientFirePain)
            {
                FindObjectOfType<HealthManager>().HurtPlayer(damageToGive);
            }
        }
    }
}
