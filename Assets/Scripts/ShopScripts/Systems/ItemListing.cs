using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemListing : MonoBehaviour
{
	public ShopSystem shopSystem;
	public int price;
	public int quantity;
	public Text priceText;
	public Text quantityText;

	void Start()
    {
		priceText.text = price.ToString();
		UpdateQuantity();
	}

	public void ReduceQuantity()
    {
		quantity--;
		UpdateQuantity();
    }

	public void ButtonClicked()
	{
		if (quantity > 0)
        {
			shopSystem.BuyFromShop(this);
        }
	}

	void UpdateQuantity()
	{
		quantityText.text = quantity.ToString();
	}
}
