using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains a list of all the item's prefabs used in the game. 
/// It's a useful tool to access the original prefabs of the items instead of the instances.
/// </summary>
public class ItemDictionary : MonoBehaviour
{
    public static ItemDictionary instance;

    [SerializeField] Item[] items;

    void Awake(){
        instance = this;
    }

    public Item getItemByName(string itemName){
        foreach (var item in items)
        {
            if (item.itemName==itemName)
                return item;
        }
        return null;
    }
}
