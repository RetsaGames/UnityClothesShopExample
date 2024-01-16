using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI instance;

    [Header("References")]
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject shop;
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
    }

    public void TurnPressEToInteract(bool value){
        pressEToInteract.SetActive(value);
    }

    public void ToggleShop(){
        inventory.SetActive(false);

        shop.SetActive(!shop.activeSelf);

        if (shop.activeSelf){
            //Fill player items
            List<Item> playerItems = getInventoryItemList(inventoryCellContainer);
            AssignItemsToContainer(shopPlayerCellContainer,playerItems);

            //Fill shopkeeper inventory
            AssignItemsToContainer(shopkeeperCellContainer,currentShop.items);
        }
        else{
            //Fill player inventory items
            List<Item> playerItems = getInventoryItemList(shopPlayerCellContainer);
            AssignItemsToContainer(inventoryCellContainer,playerItems);

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
}
