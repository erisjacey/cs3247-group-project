using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSystem : MonoBehaviour
{
	public bool shopOpen = false;

	[Header("UI")]
	public GameObject shopUI;
	public GameObject currencyCountUI;

	public void OpenShop()
	{
		shopOpen = true;
		currencyCountUI.SetActive(false);
		//playerMoneyValue = FindObjectOfType<OrbPickup>().orbNum;
		shopUI.SetActive(true);
	}

	public void CloseShop()
	{
		//FindObjectOfType<OrbPickup>().SetNewOrbNum(playerMoneyValue);
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
