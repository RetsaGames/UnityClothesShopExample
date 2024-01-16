using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    public static Cursor instance; 

    [Header("Properties")]
    [SerializeField]private Item item;

    [Header("References")]
    [SerializeField]private Canvas canvas;
    [SerializeField]private Image icon;

    private InventoryCell selectedCell;
    public InventoryCell mouseOverCell;

    void Awake(){
        instance = this;
    }

    public void Update()
    {
        //Move this object to the mouse position
        Vector2 position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition, canvas.worldCamera,
            out position);

        transform.position = canvas.transform.TransformPoint(position);
        //*************************************

        if (Input.GetButtonDown("Grab")){
            if (mouseOverCell){
                mouseOverCell.GrabItem();
            }
        }

        if (Input.GetButtonUp("Grab") && item){
            if (mouseOverCell){
                Debug.Log("Item Move");
                mouseOverCell.setItem(item);
            }
            else{
                selectedCell.setItem(item);
            }
            removeItem();
            selectedCell = null;
        }
    }

    public void pickItem(Item newItem,InventoryCell cell){
        selectedCell = cell;
        item = newItem;
        icon.gameObject.SetActive(true);
        icon.sprite = item.icon;
    }

    public void removeItem(){
        item = null;
        icon.gameObject.SetActive(false);
    }

    public void SetMouseOverCell(InventoryCell inventoryCell){
        mouseOverCell = inventoryCell;
    }

    public void RemoveMouseOverCell(InventoryCell inventoryCell){
        if (mouseOverCell == inventoryCell){
            mouseOverCell = null;
        }
    }
}
