using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Image icon;
    public Text itemName;
    public Text amount;
    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        Debug.Log("Slot filled with " + item.name);

        icon.sprite = item.icon;
        icon.enabled = true;
        itemName.text = item.name;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        itemName.text = "";

    }
    public void SetAmount(int amt)
    {
        amount.text = amt.ToString();
    }
}
