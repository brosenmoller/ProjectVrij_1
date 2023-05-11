using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "new Item")]
public class Item : ScriptableObject
{
    public string itemName = "";
    public string itemDescription = "";

    public Sprite UISprite;
}
