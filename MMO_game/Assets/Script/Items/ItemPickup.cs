using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ItemPickup : Interactable
{
    public Item item;


    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking Up "+ item.name);
       
        bool wasPickedUp = Inventory.instance.Add(item);
        PlayerManager.instance.player.GetComponent<PlayerCommands>().SendMessageToServer("Trying to Add item to inventory. pick up success: " + wasPickedUp);
        if (wasPickedUp)
        {
            Debug.Log("call commandar");
            GameObject commandar = PlayerManager.instance.player;
            if (commandar != null)
            {
               commandar.GetComponent<PlayerCommands>().DestroyOnServer(gameObject);
            }

        }


    }


}
