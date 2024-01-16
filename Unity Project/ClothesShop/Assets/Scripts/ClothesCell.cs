using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

/// <summary>
/// The cell in the inventory UI that represents the full body clothing being worn by the player
/// </summary>
public class ClothesCell : InventoryCell
{
    protected override void initiate(){
        Actor playerActor = PlayerController.instance.GetComponent<Actor>();
        var clothes = playerActor.GetClothes();

        if (clothes){
            item = ItemDictionary.instance.getItemByName(clothes.GetComponent<Item>().itemName);
        }

        if (item){
            base.setItem(item);
        }
    }

    public override void setItem(Item newItem){
        base.setItem(newItem);

        Actor playerActor = PlayerController.instance.GetComponent<Actor>();
        GameObject clothes = Instantiate(newItem.gameObject,playerActor.transform);
        clothes.transform.localPosition = Vector3.zero;
        playerActor.SetClothes(clothes.GetComponent<SpriteAnimations>());
    }

    public override void removeItem(){
        base.removeItem();
        Actor playerActor = PlayerController.instance.GetComponent<Actor>();
        playerActor.RemoveClothes();
    }

    public override bool CanReceiveItem(Item newItem){
        if (item){
            return false;
        }
        else if (newItem.itemType != ItemType.Clothes){
            return false;
        }
        else{
            return true;
        }
    }
}
