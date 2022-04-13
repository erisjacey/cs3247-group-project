using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[4, 9];
    public string[] shopItemDesc = new string[9];
    public bool shopOpen = false;
    private int currency;

    [SerializeField] GameObject shopUI;
    [SerializeField] Text currencyUI;

    // Start is called before the first frame update
    void Start()
    {
        // ----- ItemID ----- //
        // First Scene
        shopItems[1, 1] = 1; // Health +20
        shopItems[1, 2] = 2; // Speed +2

        // Second Scene
        shopItems[1, 3] = 3; // Health +30
        shopItems[1, 4] = 4; // Speed +2
        shopItems[1, 5] = 5; // Melee Damage +5

        // Third Scene
        shopItems[1, 6] = 6; // Health +30
        shopItems[1, 7] = 7; // Ranged Damage +10
        shopItems[1, 8] = 8; // Fire Immunity

        // ----- Price ----- //
        // First Scene
        shopItems[2, 1] = 8; // Health +20
        shopItems[2, 2] = 5; // Speed +2

        // Second Scene
        shopItems[2, 3] = 10; // Health +30
        shopItems[2, 4] = 5; // Speed +2
        shopItems[2, 5] = 8; // Melee Damage +5

        // Third Scene
        shopItems[2, 6] = 10; // Health +30
        shopItems[2, 7] = 10; // Ranged Damage +10
        shopItems[2, 8] = 10; // Fire Immunity

        // ----- Quantity ----- //  
        // First Scene
        shopItems[3, 1] = 1; // Health +20
        shopItems[3, 2] = 1; // Speed +2

        // Second Scene
        shopItems[3, 3] = 1; // Health +30
        shopItems[3, 4] = 2; // Speed +2
        shopItems[3, 5] = 1; // Melee Damage +5

        // Third Scene
        shopItems[3, 6] = 1; // Health +30
        shopItems[3, 7] = 1; // Ranged Damage +10
        shopItems[3, 8] = 1; // Fire Immunity

        // ----- Description ----- //
        shopItemDesc[1] = "Max Health +20";
        shopItemDesc[2] = "Movement Speed +2";
        shopItemDesc[3] = "Max Health +30";
        shopItemDesc[4] = "Movement Speed +2";
        shopItemDesc[5] = "Sword Damage +5";
        shopItemDesc[6] = "Max Health +30";
        shopItemDesc[7] = "Fireball Damage +10";
        shopItemDesc[8] = "Immunity to ambient fire";
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

            // play sound
            FindObjectOfType<AudioManager>().Play("Money");
        }
    }
}
