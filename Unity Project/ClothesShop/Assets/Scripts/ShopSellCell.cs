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

    public override bool CanReceiveItem(Item newItem){
        int playerCoins = PlayerController.instance.GetComponent<Actor>().coins;

        if (item){
            return false;
        }
        else if (playerCoins - newItem.price < 0){
            return false;
        }
        else{
            return true;
        }
    }

    public override void onItemReceived(){
        PlayerController.instance.GetComponent<Actor>().coins -= item.price;
        UI.instance.updatePriceText();
    }
}
