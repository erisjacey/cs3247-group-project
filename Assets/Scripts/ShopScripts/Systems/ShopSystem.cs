using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSystem : MonoBehaviour
{
	public bool shopOpen = false;
	public int playerMoneyValue;

	[Header("UI")]
	public GameObject shopUI;
	public Text playerMoney;

	public void OpenShop()
	{
		shopOpen = true;
		UpdateMoneyUI();
		shopUI.SetActive(true);
	}

	public void BuyFromShop(ItemListing item)
	{
        if (playerMoneyValue - item.price < 0)
        {
            return;
        }

		playerMoneyValue -= item.price;
		item.ReduceQuantity();
		UpdateMoneyUI();
	}

	void UpdateMoneyUI()
	{
		playerMoney.text = playerMoneyValue.ToString();
	}

	public void CloseShop()
	{
		shopUI.SetActive(false);
		shopOpen = false;
	}

	void Update()
	{
		if (shopOpen && Input.GetKeyDown(KeyCode.P))
		{
			shopUI.SetActive(false);
			shopOpen = false;
		}
	}
}
