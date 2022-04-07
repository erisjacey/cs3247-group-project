using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public Text PriceTxt;
    public Text QtyTxt;
    public PowerupEffect powerupEffect;

    // Update is called once per frame
    void Update()
    {
        ShopManager shopManager = FindObjectOfType<ShopManager>();
        PriceTxt.text = shopManager.shopItems[2, ItemID].ToString();
        QtyTxt.text = shopManager.shopItems[3, ItemID].ToString();
    }
}
