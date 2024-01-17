using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Manages the game's user inferface 
/// </summary>
public class UI : MonoBehaviour
{
    public static UI instance;

    [Header("References")]
    [SerializeField] private GameObject inventory;
    [SerializeField] private TextMeshProUGUI InventoryCoinText;
    [SerializeField] private GameObject shop;
    [SerializeField] private TextMeshProUGUI shopCoinText;
    [SerializeField] private GameObject pressEToInteract;
    [SerializeField] private GameObject inventoryCellContainer;
    [SerializeField] private GameObject shopPlayerCellContainer;
    [SerializeField] private GameObject shopkeeperCellContainer;
    
    private Shop currentShop;

    void Awake(){
        instance = this;
    }

    public void ToggleInventory(){
        shop.SetActive(false);

        inventory.SetActive(!inventory.activeSelf);

        if (inventory.activeSelf){
            Actor playerActor = PlayerController.instance.GetComponent<Actor>();

            //Update coin's text
            InventoryCoinText.text = playerActor.coins.ToString();

            AssignItemsToContainer(inventoryCellContainer,playerActor.inventory);
        }
        else{
            Actor playerActor = PlayerController.instance.GetComponent<Actor>();

            //Fill player inventory items
            List<Item> playerItems = getInventoryItemList(inventoryCellContainer);
            playerActor.inventory = playerItems;
        }
    }

    public void TurnPressEToInteract(bool value){
        pressEToInteract.SetActive(value);
    }

    public void ToggleShop(){
        inventory.SetActive(false);

        shop.SetActive(!shop.activeSelf);

        if (shop.activeSelf){
            Actor playerActor = PlayerController.instance.GetComponent<Actor>();

            //Fill player items
            AssignItemsToContainer(shopPlayerCellContainer,playerActor.inventory);

            //Fill shopkeeper inventory
            AssignItemsToContainer(shopkeeperCellContainer,currentShop.items);

            //Update coin's text
            shopCoinText.text = playerActor.coins.ToString();
        }
        else{
            Actor playerActor = PlayerController.instance.GetComponent<Actor>();
            
            //Fill player inventory items
            List<Item> playerItems = getInventoryItemList(shopPlayerCellContainer);
            playerActor.inventory = playerItems;

            //Fill shopkeeper inventory items
            currentShop.items = getInventoryItemList(shopkeeperCellContainer);
        }
    }

    private List<Item> getInventoryItemList(GameObject cellContainer){
        List<Item> result = new List<Item>();
        foreach (InventoryCell inventoryCell in cellContainer.GetComponentsInChildren<InventoryCell>())
        {
            result.Add(inventoryCell.getItem());
        }

        return result;
    }

    private void AssignItemsToContainer(GameObject cellContainer,List<Item> items){
        InventoryCell[] cells = cellContainer.GetComponentsInChildren<InventoryCell>();

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i]){
                cells[i].setItem(items[i]);
            }
            else{
                cells[i].removeItem();
            }
        }
    }

    public void setCurrentShop(Shop shop){
        currentShop = shop;
    }

    public void updatePriceText(){
        shopCoinText.text = PlayerController.instance.GetComponent<Actor>().coins.ToString();
    }
}
