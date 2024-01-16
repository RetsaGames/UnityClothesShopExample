using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour,IDeselectHandler,IPointerEnterHandler,IPointerExitHandler
{
    [Header("Properties")]
    [SerializeField] private Item item;

    [Header("References")]
    [SerializeField] private Image icon;
    [SerializeField] private Button button;

    void Start()
    {
        if (item){
            setItem(item);
        }
    }

    public void setItem(Item newItem){
        item = newItem;
        icon.gameObject.SetActive(true);
        icon.sprite = item.icon;
    }

    public void removeItem(){
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

    public void OnDeselect(BaseEventData eventData)
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.instance.SetMouseOverCell(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.instance.RemoveMouseOverCell(this);
    }
}
