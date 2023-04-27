using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Item", fileName = "new Item")]
public class Item : ScriptableObject, IEquatable<Item>
{
    public string itemName = "";
    public string itemDescription = "";

    public Sprite UISprite;

    #region Equality Comparison Overriding
    public static bool operator == (Item a, Item b) => a.itemName == b.itemName;
    public static bool operator != (Item a, Item b) => a.itemName != b.itemName;
    public override bool Equals(object obj) => obj is Item item && itemName == item.itemName;
    public override int GetHashCode() => itemName.GetHashCode();
    public bool Equals(Item other) => itemName == other.itemName;
    #endregion
}
