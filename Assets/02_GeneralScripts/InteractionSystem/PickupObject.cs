using UnityEngine;

public class PickupObject : InteractableObject
{
    private bool isHoldingObject = false;
    private Transform holdingParent;

    protected override void PerformInteraction()
    {
        if (isHoldingObject) { return; }

        //if (holdingParent == null) { holdingParent = playerInteractionDetector.gameObject.GetComponentInChildren<Camera>().transform; }
        if (holdingParent == null) { holdingParent = playerInteractionDetector.transform; }

        transform.SetParent(holdingParent);

        playerInteractionDetector.SetCanInteract(false);
        isHoldingObject = true;
    }

    private void Update()
    {
        if (GameManager.InputManager.playerInputActions.PlayerActionMap.Interact.WasPressedThisFrame() && isHoldingObject) 
        {
            transform.SetParent(null);
            Invoke(nameof(ReEnableInteractionDetector), .1f);
            isHoldingObject = false;
        }
    }

    private void ReEnableInteractionDetector()
    {
        playerInteractionDetector.SetCanInteract(true);
    }
}
