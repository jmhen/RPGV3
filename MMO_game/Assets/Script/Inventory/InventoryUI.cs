using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{
    [SerializeField] Transform itemsParent;
    [SerializeField] GameObject inventoryUI;
    [SerializeField] List<Item> items;
    bool isDefaultLoaded;
 
 

    InventorySlot[] slots;
    // Start is called before the first frame update
    private void Start()
    {
        isDefaultLoaded = false;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        Inventory.instance.onItemChangedCallBack += UpdateUI;
        Toast.toast.ShowToast("CallBack="+Inventory.instance.onItemChangedCallBack, 2);


    }
    private void Update()
    {
        if(Inventory.instance.onItemChangedCallBack == null)
        {
            Inventory.instance.onItemChangedCallBack += UpdateUI;
        }
    }


    // Update is called once per frame
    public void TriggerInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        if (!isDefaultLoaded)
        {
            PlayerManager.instance.player.GetComponent<PlayerCommands>().SendMessageToServer("Trying to load base items");
            PlayerManager.instance.player.GetComponent<PlayerCommands>().SendMessageToServer("OnItemChangedCallBack: " + Inventory.instance.onItemChangedCallBack);
            StartCoroutine(LoadInventoryItems());
            Toast.toast.ShowToast("Loading default items", 2);
            isDefaultLoaded = true;
        }

    }
    IEnumerator LoadInventoryItems()
    {
        Debug.Log("itemcount:" +items.Count);

        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log(items[i].name);
            Inventory.instance.Add(items[i]);
            PlayerManager.instance.player.GetComponent<PlayerCommands>().SendMessageToServer("Trying to Add base items: count:  " + items.Count);

            yield return null;
        }

    }



    void UpdateUI()
    {
        PlayerManager.instance.player.GetComponent<PlayerCommands>().SendMessageToServer("Trying to update inventory UI,slotlength: " + slots.Length);
        for(int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.instance.items.Count)
            {
                slots[i].AddItem(Inventory.instance.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
