using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SkeletonKnockback : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other){
		SkeletonAI SkeletonAI = transform.parent.GetComponent<SkeletonAI>();
		Vector3 knockback = (transform.position - other.transform.position).normalized / 2.0f;
		if (other.tag == "MyWeapon")
		{	
            SkeletonAI.Knockback(knockback);
		}
	}
}
