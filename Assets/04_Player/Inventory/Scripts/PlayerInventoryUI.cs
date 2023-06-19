using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventorySlotPrefab;

    private readonly Dictionary<Item, GameObject> itemsInSlots = new();

    private Image inventoryBackground;

    private void Awake()
    {
        inventoryBackground = GetComponent<Image>();
    }

    public void AddUIItem(Item[] items)
    {
        foreach (Item item in items)
        {
            AddUIItem(item);
        }
    }

    public void AddUIItem(Item item)
    {
        if (itemsInSlots.ContainsKey(item)) { return; }

        inventoryBackground.enabled = true;

        GameObject newSlot = Instantiate(inventorySlotPrefab, transform);
        newSlot.GetComponent<Image>().sprite = item.UISprite;

        itemsInSlots.Add(item, newSlot);
    }

    public void RemoveUIItem(Item item)
    {
        if (!itemsInSlots.ContainsKey(item)) { return; }
        
        Destroy(itemsInSlots[item]);
        itemsInSlots.Remove(item);

        if (itemsInSlots.Count == 0) 
        {
            inventoryBackground.enabled = false;
        }
    }
}
