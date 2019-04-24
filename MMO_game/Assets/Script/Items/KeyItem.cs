using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/KeyItem")]
public class KeyItem : Item
{
    public bool removeable;
    //future proof placeholder, maybe to allow addition of flags to the item (eg. cannot be dropped)
    public override void RemoveFromInventory() //overridden here to ensure some items cannot be removed
    {
        if (removeable)
        {
            //Inventory.instance.Remove(this);
        }
        else
        {
            Debug.Log(name + " cannot be removed as it is a key item");
        }
    }

    public void KeyRemove()
    {
        //Inventory.instance.Remove(this);
    }
}
