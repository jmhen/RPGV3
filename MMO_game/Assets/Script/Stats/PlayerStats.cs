using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    EquipmentManager equipmentManager; 

    // Start is called before the first frame update
    void Start()
    {
        equipmentManager = EquipmentManager.instance;
        equipmentManager.onEquipmentChanged += OnEquipChanged;
        Debug.Log("Starting and add callback");


    }

    void OnEquipChanged(Equipment newItem, Equipment OldItem)
    {
        Debug.Log("On Equipment Change, add/remove modifier");
        if (newItem != null)
        {
            hp.AddModifier(newItem.hpModifier);
            mp.AddModifier(newItem.mpModifier);
            attack.AddModifier(newItem.damageModifier);
            defense.AddModifier(newItem.armorModifier);
            magicAttack.AddModifier(newItem.magicDamageModifier);
            magicDefense.AddModifier(newItem.magicResistModifier);
        }


        if (OldItem != null)
        {
            hp.RemoveModifier(OldItem.hpModifier);
            mp.RemoveModifier(OldItem.mpModifier);
            attack.RemoveModifier(OldItem.damageModifier);
            defense.RemoveModifier(OldItem.armorModifier);
            magicAttack.RemoveModifier(OldItem.magicDamageModifier);
            magicDefense.RemoveModifier(OldItem.magicResistModifier);
        }
    }



    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();

    }
}
