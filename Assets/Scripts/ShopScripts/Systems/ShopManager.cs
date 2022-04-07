using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[4, 4];
    public bool shopOpen = false;
    private int currency;

    [SerializeField] GameObject shopUI;
    [SerializeField] Text currencyUI;

    // Start is called before the first frame update
    void Start()
    {
        // ItemID  
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;

        // Price  
        shopItems[2, 1] = 2;
        shopItems[2, 2] = 4;
        shopItems[2, 3] = 6;

        // Quantity  
        shopItems[3, 1] = 1;
        shopItems[3, 2] = 2;
        shopItems[3, 3] = 3;
    }

    void Update()
	{
        currency = FindObjectOfType<OrbCounter>().GetOrbCount();
        currencyUI.text = currency.ToString();
    }

	public void OpenShop()
	{
		shopOpen = true;
		shopUI.SetActive(true);
	}

	public void CloseShop()
	{
        shopOpen = false;
		shopUI.SetActive(false);
	}

    public void Buy()
    {
        EventSystem eventSystem = FindObjectOfType<EventSystem>();
        GameObject ButtonRef = eventSystem.currentSelectedGameObject;

        if ((currency >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID]) && (shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID] > 0))
        {
            // charge customer
            currency -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            
            // reduce quantity left
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]--;

            // apply effect
            ButtonRef.GetComponent<ButtonInfo>().powerupEffect.Apply(GameObject.FindGameObjectWithTag("Player"));

            // update UI data
            FindObjectOfType<OrbCounter>().SetCount(currency);
        }
    }
}
