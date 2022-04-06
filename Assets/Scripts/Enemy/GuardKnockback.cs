using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GuardKnockback : MonoBehaviour
{   

    private void OnTriggerEnter2D(Collider2D other){
		GuardAI guard = transform.parent.GetComponent<GuardAI>();
		Vector3 knockback = (transform.position - other.transform.position).normalized;
		if (other.tag == "MyWeapon")
		{	
			Debug.Log("Here");
            guard.Knockback(knockback);
		} else if (other.tag == "Player")
		{
			guard.Knockback(knockback);
		}
	}
}
