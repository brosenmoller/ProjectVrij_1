using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : InteractableObject
{
    public Item pickUpItem;

    public override void Interact()
    {
        if(pickUpItem == null)
        {
            Debug.LogWarning("No Item is set for this Pickup: " + this.gameObject.name);
        }

        //PlayerInventory.AddItem(pickUpItem);


        this.gameObject.SetActive(false);
    }
}
