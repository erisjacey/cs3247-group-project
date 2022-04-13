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
    public GameObject oosOverlay;

    private ShopManager shopManager;

    // Update is called once per frame
    void Update()
    {
        shopManager = FindObjectOfType<ShopManager>();
        PriceTxt.text = shopManager.shopItems[2, ItemID].ToString();
        QtyTxt.text = shopManager.shopItems[3, ItemID].ToString();

        if (shopManager.shopItems[3, ItemID] <= 0)
        {
            oosOverlay.SetActive(true);
        }
    }

    public void ShowTooltip()
    {
        Tooltip.ShowTooltip_Static(shopManager.shopItemDesc[ItemID]);
    }
    public void HideTooltip()
    {
        Tooltip.HideTooltip_Static();
    }
}
