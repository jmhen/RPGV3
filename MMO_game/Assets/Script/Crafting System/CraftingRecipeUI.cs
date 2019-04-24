using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingRecipeUI : MonoBehaviour
{
    private CraftingRecipe craftingRecipe;
    public CraftingRecipe CraftingRecipe
    {
        get { return craftingRecipe; }
        set { SetCraftingRecipe(value); }
    }
    Inventory inventory;
    [SerializeField] RectTransform arrowParent;
    [SerializeField] ItemSlot[] itemSlots;


    void Start()
    {
        Debug.Log("CRAFTING WINDOW: slot count = " + itemSlots.Length);
        inventory = Inventory.instance; // init of inventory
        Debug.Log(inventory);
    }

    public void StartCrafting()
    {
        Debug.Log("Let's Craft!");
        craftingRecipe.Craft(inventory);
    }



    public void SetCraftingRecipe(CraftingRecipe newCraftingRecipe)
    {
        craftingRecipe = newCraftingRecipe;

        if(craftingRecipe != null) 
        {
            Debug.Log("New Recipe!");
            int slotIndex = 0;
            slotIndex = SetSlots(craftingRecipe.materials, slotIndex);  
            arrowParent.SetSiblingIndex(slotIndex);
            slotIndex = SetSlots(craftingRecipe.results, slotIndex);
            for (int i = slotIndex; i < itemSlots.Length; i++)
            {
                itemSlots[i].gameObject.SetActive(false);
            }
            gameObject.SetActive(true); ;
        }
        else
        {
            Debug.Log("Hide View!");
            gameObject.SetActive(false);
        }
    }

    private int SetSlots(IList<ItemAmount> itemAmountList, int slotIndex)
    {
        for(int i = 0; i < itemAmountList.Count; i++, slotIndex++)
        {
            ItemAmount itemAmount = itemAmountList[i];
            ItemSlot itemSlot = itemSlots[slotIndex];
            Debug.Log(itemSlot);

            itemSlot.AddItem(itemAmount.item);
            //need to change child of slot which is a text box into itemAmount.amount
            //itemSlot.Amount = itemAmount.amount; items not stackable anymore
            itemSlot.SetAmount(itemAmount.amount); 
            itemSlot.transform.parent.gameObject.SetActive(true);

        }
        return slotIndex;
    }

    public ItemSlot[] getItemSlots()
    {
        return itemSlots;   
    }
}
 