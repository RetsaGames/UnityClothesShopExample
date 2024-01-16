using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private bool playerClose = false;

    public List<Item> items;

    void Update(){
        if (playerClose && Input.GetButtonDown("Interact")){
            UI.instance.setCurrentShop(this);
            UI.instance.ToggleShop();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        playerClose = true;
        UI.instance.TurnPressEToInteract(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        playerClose = false;
        UI.instance.TurnPressEToInteract(false);
    }
}
