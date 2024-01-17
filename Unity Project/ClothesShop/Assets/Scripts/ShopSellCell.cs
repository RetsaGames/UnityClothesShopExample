using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// A cell in the Shop UI (player's side).
/// </summary>
public class ShopSellCell : InventoryCell
{
    [SerializeField] private GameObject priceContainer;
    [SerializeField] protected TextMeshProUGUI priceText;

    public override void setItem(Item newItem){
        base.setItem(newItem);

        priceContainer.SetActive(true);
        priceText.text = newItem.price.ToString();
    }

    public override void removeItem(){
        base.removeItem();
        
        priceContainer.SetActive(false);
    }
}
