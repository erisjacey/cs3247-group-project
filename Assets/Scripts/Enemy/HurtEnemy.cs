using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive = 5;
    private string currentGameObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentGameObject = gameObject.name;

        if (currentGameObject == "HitBox")
        {
            damageToGive = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().swordDamage;
        }
        else if (currentGameObject == "Fireball(Clone)")
        {
            damageToGive = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().fireballDamage;
        }

        if (other.tag == "Damageable")
        {
            EnemyHealthManager eHealthMan;
            GameObject otherObj = other.gameObject;
            GameObject parentObj = otherObj.transform.parent.gameObject;
            eHealthMan = parentObj.GetComponent<EnemyHealthManager>();
            eHealthMan.HurtEnemy(damageToGive);
        } 
        else if (other.tag == "Boss")
        {
            BossHealth bossHealth = other.gameObject.GetComponent<BossHealth>();
            AngryPlayerHealth angryPlayerHealth = other.gameObject.GetComponentInChildren<AngryPlayerHealth>();

            if (bossHealth != null) {
                bossHealth.TakeDamage(damageToGive);
            } else if (angryPlayerHealth != null) {
                angryPlayerHealth.TakeDamage(damageToGive);
            }

        }

        if (other.tag == "FakeBoss")
        {
            FakeBossHealth eHealthMan;
            eHealthMan = other.gameObject.GetComponent<FakeBossHealth>();
            eHealthMan.HurtFakeBoss(damageToGive);
        }
    }
}
