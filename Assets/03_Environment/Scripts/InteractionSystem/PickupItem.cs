using UnityEngine;

public class PickupItem : InteractableObject
{
    [SerializeField] private Item pickUpItem;

    protected override void PerformInteraction()
    {
        if (pickUpItem == null)
        {
            Debug.LogWarning("No Item is set for this Pickup: " + gameObject.name);
            return;
        }

        playerInventory.AddItem(pickUpItem);

        gameObject.SetActive(false);
    }
}
