using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;

    public int damageModifier;
    public int armorModifier;
    public int magicDamageModifier;
    public int magicResistModifier;
    public int hpModifier;
    public int mpModifier;

    public override void Use()
    {
        //insert class checking here, do not let characters wear equipment cross class, maybe ensure class ID matches the entry in allowedClasses
        EquipmentManager.instance.Equip(this);
        Debug.Log("Equipped");
        RemoveFromInventory();
        Debug.Log("Removed" + this.name);
    }

}

public enum EquipmentSlot {Head, Chest, Legs, Weapon, Shield, Feet, Hands, Ring, Necklace};
public enum EquipmentMeshRegion { Legs, Arms, Torso}; // correspond to blendshapes
