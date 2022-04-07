using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public Text PriceTxt;
    public Text QtyTxt;
    public GameObject ShopManager;
    public PowerupEffect powerupEffect;

    // Update is called once per frame
    void Update()
    {
        PriceTxt.text = ShopManager.GetComponent<ShopManager>().shopItems[2, ItemID].ToString();
        QtyTxt.text = ShopManager.GetComponent<ShopManager>().shopItems[3, ItemID].ToString();
    }
}
