using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An <c>Item</c> is an object than can be equipped by an <c>Actor</c>.
/// </summary>
public class Item : MonoBehaviour
{
    public string itemName;
    public Sprite icon;
    public ItemType itemType;
    public int price;
}
