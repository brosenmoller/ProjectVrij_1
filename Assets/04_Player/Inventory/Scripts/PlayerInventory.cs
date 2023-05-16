using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<Item> items = new();

    [Header("References")]
    [SerializeField] private PlayerInventoryUI playerInventoryUIView;

    public void AddItem(Item item)
    {
        if (items.Contains(item) || item == null) { return; }

        items.Add(item);
        playerInventoryUIView.AddUIItem(item);
    }

    public void RemoveItem(Item item)
    {
        if (!items.Contains(item) || item == null) { return; }

        items.Remove(item);
        playerInventoryUIView.RemoveUIItem(item);
    }
    public bool HasItem(Item item)
    {
        return item != null && items.Contains(item);
    }

    public bool HasItems(Item[] items)
    {
        foreach (Item item in items)
        {
            if (!HasItem(item)) 
            {
                return false;
            }
        }

        return true;
    }
}
