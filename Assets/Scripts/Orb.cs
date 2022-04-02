using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
	public OrbCounter OrbCounterUI;
	public string playerTag;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag.Equals(playerTag))
		{
			Debug.Log("collision detected");
			OrbCounterUI.IncreaseCount();
			PickUp();
		}
	}

	void PickUp()
    {
		Destroy(gameObject);
    }
}
