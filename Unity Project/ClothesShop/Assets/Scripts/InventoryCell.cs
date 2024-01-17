using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// A cell in the inventory UI.
/// </summary>
public class InventoryCell : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [Header("Properties")]
    [SerializeField] protected Item item;

    [Header("References")]
    [SerializeField] protected Image icon;

    void Start()
    {
        initiate();
    }

    protected virtual void initiate(){
        if (item){
            setItem(item);
        }
    }

    public virtual void setItem(Item newItem){
        item = newItem;
        icon.gameObject.SetActive(true);
        icon.sprite = item.icon;
    }

    public virtual void removeItem(){
        item = null;
        icon.gameObject.SetActive(false);
    }

    public void GrabItem()
    {
        if (item){
            Cursor.instance.pickItem(item,this);
            removeItem();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.instance.SetMouseOverCell(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.instance.RemoveMouseOverCell(this);
    }

    public virtual bool CanReceiveItem(Item newItem){
        if (item){
            return false;
        }
        else{
            return true;
        }
    }

    public Item getItem(){
        return item;
    }

    public virtual void onItemReceived(){
        
    }
}
