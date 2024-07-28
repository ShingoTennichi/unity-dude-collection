using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    public List<Item> ItemList = new List<Item>();
    // public Dictionary<string, Item> ItemData = new Dictionary<string, Item>();

    public void addItem(Item item) {
        ItemList.Add(item);
    }

    public void addItem (Item item, int count)
    {
        Item targetItem = ItemList.FirstOrDefault(i => i.Name == item.Name);
        if (targetItem == null)
        {
            addItem(item);
        }
        else
        {
            targetItem.Count += count;
        }
    }
}


[System.Serializable]
public class Item
{
    public string Name;
    public string Description;
    public int Count;
    public Sprite Image;
}
