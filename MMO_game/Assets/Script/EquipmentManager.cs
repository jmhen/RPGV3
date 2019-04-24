using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Equipment[] defaultItems;
    public SkinnedMeshRenderer targetMesh; //will be using body mesh as target mesh
    public Equipment[] currentEquipments;
    SkinnedMeshRenderer[] currentMeshes;


    // Callback for when an item is equipped/unequipped
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment OldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;   //get a reference to our inventory

        //initialize currentEquipment base on number of equipment slots
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipments = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
        Debug.Log("EquipDefualtItems");
        EquipDefaultItems();
 

    }

    //Equip a new item
    public void Equip (Equipment newItem)
    {
        //Find out what slot the item fits in
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = Unequip(slotIndex);


        //if there was already an item in the slot
        //make sure to put it back in the inventory
        if (currentEquipments[slotIndex] != null) { }

        //an item has been equipped so we trigger the callback
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
            Debug.Log("onEquipmentChanged invoked");
        }
        Debug.Log(onEquipmentChanged);
        Debug.Log("setting blendShapes");
        SetEquipmetnBlendShapes(newItem, 100);

        //insert the item into the slot
        currentEquipments[slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;

        //tell the new mesh to deform based on bones of target mesh
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;

        //insert to currentMesh array
        currentMeshes[slotIndex] = newMesh;
    }

    //unequip an item with particular index
    public Equipment Unequip(int slotIndex)
    {
        //only do this if an item is there
        if (currentEquipments[slotIndex] != null)
        {
            if (currentMeshes[slotIndex] != null) {
                Destroy(currentMeshes[slotIndex].gameObject); 
            }

            Equipment oldItem = currentEquipments[slotIndex];
            SetEquipmetnBlendShapes(oldItem, 0);
            inventory.Add(oldItem);

            currentEquipments[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
            return oldItem;
        }
        return null;
    }

    public void UnequipAll()
    {
        for(int i=0;i<currentEquipments.Length; i++)
        {
            Unequip(i);

        }
        EquipDefaultItems();
    }

    void SetEquipmetnBlendShapes(Equipment item, int weight)
    {
        foreach(EquipmentMeshRegion blendShape in item.coveredMeshRegions)
        {
            targetMesh.SetBlendShapeWeight((int)blendShape,weight); //
            Debug.Log("targetMesh region " + blendShape + " set weight to " + targetMesh.GetBlendShapeWeight((int)blendShape));
        }
    }

    //Equip the default items: shirt, hair, shoes etc.
    void EquipDefaultItems()
    {
        foreach(Equipment item in defaultItems)
        {
            Equip(item);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }



}


