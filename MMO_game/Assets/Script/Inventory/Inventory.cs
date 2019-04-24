using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour//,IItemContainer
{
    [SerializeField] public static Inventory instance;
    public List<Item> items; //seperates data from UI, even though itemSlots can contain items by themselves

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than 1 instance of Inventory found");
            return;
        }
        instance = this;
    }


    public delegate void OnItemChangedCallBack();
    public OnItemChangedCallBack onItemChangedCallBack;



    public bool Add(Item item)
    { 
        if (!item.isDefaultItem)
        {   
            if(items.Count >= 21)
            {
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(item);
            PlayerManager.instance.player.GetComponent<PlayerCommands>().SendMessageToServer("OnItemChangedCallBack: " + onItemChangedCallBack);
            if (onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();

        }
        return true;
    }

    public bool Remove(Item item)
    {
        items.Remove(item);
        Debug.Log(onItemChangedCallBack);
        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
        return true;
    }

    public bool ContainsItem(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == item)
            {
                return true;

            }
        }
        return false;
    }

    public bool IsFull()
    {
        if (items.Count >= 20)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int ItemCount(Item item)
    {
        int count = 0;
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i] == item)
            {
                count++;
            }
        }
        return count;
    }


}
