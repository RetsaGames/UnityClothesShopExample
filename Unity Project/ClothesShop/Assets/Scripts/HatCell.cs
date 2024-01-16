using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The cell in the inventory UI that represents the hat being worn by the player
/// </summary>
public class HatCell : InventoryCell
{
    protected override void initiate(){
        Actor playerActor = PlayerController.instance.GetComponent<Actor>();
        var hat = playerActor.GetHat();

        if (hat){
            item = ItemDictionary.instance.getItemByName(hat.GetComponent<Item>().itemName);
        }

        if (item){
            base.setItem(item);
        }
    }

    public override void setItem(Item newItem){
        base.setItem(newItem);

        Actor playerActor = PlayerController.instance.GetComponent<Actor>();
        GameObject hat = Instantiate(newItem.gameObject,playerActor.transform);
        hat.transform.localPosition = Vector3.zero;
        playerActor.SetHat(hat.GetComponent<SpriteAnimations>());
    }

    public override void removeItem(){
        base.removeItem();
        Actor playerActor = PlayerController.instance.GetComponent<Actor>();
        playerActor.RemoveHat();
    }

    public override bool CanReceiveItem(Item newItem){
        if (item){
            return false;
        }
        else if (newItem.itemType != ItemType.Hat){
            return false;
        }
        else{
            return true;
        }
    }
}
