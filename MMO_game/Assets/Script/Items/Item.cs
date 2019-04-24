using UnityEngine;


public class Item : ScriptableObject
{
    [SerializeField] int ID;
    public int itemID { get { return ID; } } //ID starts with 1 for materials, 2 for equipment, 3 for consumables, 4 for key items (for organization)
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public bool itemCap;


    public virtual void Use() //maybe remove this method, not all items can be "used" like crafting materials, define push use seperately for each subclass
    {
        //Use the item
        //Something might happen, differently
        Debug.Log("Using" + name);
        RemoveFromInventory();
    }

    public virtual void RemoveFromInventory() //removed from Equipment and added to superclass. All items should have some way of being removed, maybe give key items some sort of flag if needed
    {
        Inventory.instance.Remove(this);
    }
}
