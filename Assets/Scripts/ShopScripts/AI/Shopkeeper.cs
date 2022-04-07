using System;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
	public ShopSystem shopSystem;

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
            StartTrade();
        }
    }

    public bool StartTrade()
    {
        if (!inRange || shopSystem.shopOpen)
        {
            return false;
        }
        shopSystem.OpenShop();
        return true;
    }
}
