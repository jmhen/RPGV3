using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Consumable")]
public class Consumable : Item
{
    //public float cooldown;
    //float nextUse = 0.0F;
    //public int stackSize;

    public override void Use()
    {
        //if(nextUse == 0.0F)
        //{
        //    nextUse = Time.time;
        //}
        ////should apply an effect (eg. heal, giving buffs)
        //if (Time.time >= nextUse)
        //{
        Debug.Log("Consumed" + name);
            //nextUse = Time.time + cooldown;
            //Debug.Log("Cooldown applied");
        RemoveFromInventory();
        //}
        //else
        //{
        //    Debug.Log(name + " is still on cooldown");
        //    Debug.Log("cooldown time left is " + (nextUse - Time.time));
        //}
    }
}
