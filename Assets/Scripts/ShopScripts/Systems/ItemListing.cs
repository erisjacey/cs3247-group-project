using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemListing : MonoBehaviour
{
	public ShopSystem shopSystem;
	public int price;
	public int quantity;
	public Text priceText;
	public Text quantityText;

	public PowerupEffect powerupEffect;

	//void Start()
 //   {
	//	priceText.text = price.ToString();
	//	UpdateQuantity();
	//}

	//public void ReduceQuantity()
 //   {
	//	quantity--;
	//	UpdateQuantity();
 //   }

	//public void ButtonClicked()
	//{
	//	if (quantity > 0)
 //       {
	//		bool successPurchase = shopSystem.BuyFromShop(this);
	//		if (successPurchase)
 //           {
	//			powerupEffect.Apply(GameObject.FindGameObjectWithTag("Player"));
	//			Debug.Log("Applied buff " + powerupEffect);
 //           }
 //       }
	//}

	//void UpdateQuantity()
	//{
	//	quantityText.text = quantity.ToString();
	//}
}
