using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
    public Item item;
    [Range(1, 30)]
    public int amount;
}

[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemAmount> materials;
    public List<ItemAmount> results;
    
    public bool CanCraft(Inventory inventory)
    {
        foreach(ItemAmount itemAmount in materials)
        {
            if(inventory.ItemCount(itemAmount.item) < itemAmount.amount)
            {
                return false;
            }
        }
        return true;
    }
    
    public void Craft(Inventory inventory)
    {
        if (CanCraft(inventory)) {

            foreach (ItemAmount itemAmount in materials)
            {
                for(int i = 0; i < itemAmount.amount; i++)
                {
                    inventory.Remove(itemAmount.item);
                }
            }
            Debug.Log("items removed");

            foreach (ItemAmount itemAmount in results)
            {
                for (int i = 0; i < itemAmount.amount; i++)
                {
                    inventory.Add(itemAmount.item);
                }
            }
            Debug.Log("items added");
            Toast.toast.ShowToast("New crafted item added to your inventory!", 2);
        }
        else
        {
            Toast.toast.ShowToast("Insufficient materials", 2);
        }

    }
}
