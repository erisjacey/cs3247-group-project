using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
	if (other.tag == "Enemy")
	{
	    EnemyHealthManager eHealthMan;
            eHealthMan = other.gameObject.GetComponent<EnemyHealthManager>();
            eHealthMan.HurtEnemy(damageToGive);
	} else if (other.tag == "Boss")
	{
	    BossHealth bossHealth;
            bossHealth = other.gameObject.GetComponent<BossHealth>();
            bossHealth.TakeDamage(damageToGive);
	}
    }
}
