using UnityEngine;

public class PickupObject : InteractableObject
{
    private bool isHoldingObject = false;

    protected override void PerformInteraction()
    {
        transform.SetParent(playerInventory.transform);
        isHoldingObject = true;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && isHoldingObject) 
        {
            transform.SetParent(null);
            isHoldingObject = false;
        }
    }
}
