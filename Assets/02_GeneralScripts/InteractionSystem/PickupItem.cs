using UnityEngine;

public class PickupItem : InteractableObject
{
    [SerializeField] private Item pickUpItem;
    [SerializeField] protected AudioSource audioOnPerformed;

    protected override void PerformInteraction()
    {
        if (pickUpItem == null)
        {
            Debug.LogWarning("No Item is set for this Pickup: " + gameObject.name);
            return;
        }

        audioOnPerformed.Play();

        playerInventory.AddItem(pickUpItem);

        gameObject.SetActive(false);
    }
}
