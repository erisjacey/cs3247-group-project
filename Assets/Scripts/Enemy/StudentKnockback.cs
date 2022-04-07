using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentKnockback : MonoBehaviour
{
       private void OnTriggerEnter2D(Collider2D other){
		StudentAI studentAI = transform.parent.GetComponent<StudentAI>();
		Vector3 knockback = (transform.position - other.transform.position).normalized / 2.0f;
		if (other.tag == "MyWeapon")
		{	
            studentAI.Knockback(knockback);
		}
	}
}
