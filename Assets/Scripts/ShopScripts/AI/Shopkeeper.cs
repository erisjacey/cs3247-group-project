using System;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
	bool inRange = false;
	public GameObject tooltip;

    private void OnTriggerEnter2D(Collider2D other)
    {
		if (other.tag == "Player") 
        {
			ChangeState(true);
		}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
		if (other.tag == "Player") 
        {
			ChangeState(false);
		}
    }

	void ChangeState(bool state)
	{
		inRange = state;
		tooltip.SetActive(state);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShopManager shopManager = FindObjectOfType<ShopManager>();
            if (shopManager.shopOpen) 
            {
                shopManager.CloseShop();
            }
            else
            {
                if (inRange) shopManager.OpenShop();
            }
        }
    }
}
