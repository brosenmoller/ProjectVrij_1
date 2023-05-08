using UnityEngine;

public class PickupItem : InteractableObject
{
    [SerializeField] private Item pickUpItem;

    public override void Interact()
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
