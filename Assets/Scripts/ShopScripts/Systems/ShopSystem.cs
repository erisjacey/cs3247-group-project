using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSystem : MonoBehaviour
{
	public bool shopOpen = false;
	public int playerMoneyValue;

	[Header("UI")]
	public GameObject shopUI;
	public GameObject currencyCountUI;
	public Text currencyCountText;
	public Text playerMoney;

	public void OpenShop()
	{
		shopOpen = true;
		currencyCountUI.SetActive(false);
		playerMoneyValue = FindObjectOfType<OrbPickup>().orbNum;
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
		FindObjectOfType<OrbPickup>().SetNewOrbNum(playerMoneyValue);
		currencyCountUI.SetActive(true);
		shopUI.SetActive(false);
		shopOpen = false;
	}

	void Update()
	{
        if (shopOpen && Input.GetKeyDown(KeyCode.P))
        {
            CloseShop();
        }
    }
}
