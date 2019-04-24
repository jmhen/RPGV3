using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Material")]
public class CraftingMaterial : Item
{
    public int stackSize = 50;
    public override void Use()
    {
        //insert class checking here, do not let characters wear equipment cross class, maybe ensure class ID matches the entry in allowedClasses
        Toast.toast.ShowToast("This item is only used for crafting",2);
    }
}
