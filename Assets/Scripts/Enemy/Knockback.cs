using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Pathfinding;

public class Knockback : MonoBehaviour
{   

    private void OnTriggerEnter2D(Collider2D other){
		GuardAI guard = transform.parent.GetComponent<GuardAI>();
		Vector3 knockback = (transform.position - other.transform.position).normalized / 1.75f;
		if (other.tag == "MyWeapon")
		{	
            StartCoroutine(Holdback());
		}
	}

	IEnumerator Holdback()
    {
        GuardPath guard = transform.parent.GetComponent<GuardPath>();
		guard.DisableMove();
		yield return new WaitForSeconds(0.25f);
		guard.EnableMove();
    }
}
