using System;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
	bool inRange = false;
	public string playerTag;
	public GameObject tooltip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.transform.tag.Equals(playerTag))
		{
			ChangeState(true);
		}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
		if (collision.transform.tag.Equals(playerTag))
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
        if (Input.GetKeyDown(KeyCode.P))
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
