using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// A cell in the Shop UI (shopkeeper's side).
/// </summary>
public class ShopBuyCell : InventoryCell
{
    [SerializeField] private GameObject priceContainer;
    [SerializeField] private TextMeshProUGUI priceText;

    public override void setItem(Item newItem){
        base.setItem(newItem);

        priceContainer.SetActive(true);
        priceText.text = newItem.price.ToString();
    }

    public override void removeItem(){
        base.removeItem();

        priceContainer.SetActive(false);
    }

    protected override bool CanGrabItem(){
        int playerCoins = PlayerController.instance.GetComponent<Actor>().coins;

        if (playerCoins - item.price < 0){
            return false;
        }
        else{
            return true;
        }
    }

    public override void onItemReceived(){
        PlayerController.instance.GetComponent<Actor>().coins += item.price;
        UI.instance.updatePriceText();
    }

    protected override void onItemGrabbed(){
        PlayerController.instance.GetComponent<Actor>().coins -= item.price;
        UI.instance.updatePriceText();
    }
}
