using UnityEngine;
using UnityEngine.Events;

public class InteractableButton : InteractableObject
{
    [Header("Button Settings")]
    [SerializeField] private UnityEvent OnActivated;
    [SerializeField] private UnityEvent OnDeactivated;

    [Header("Extra Settings")]
    [SerializeField] private bool disableSwitchAfterActivation;

    [SerializeField] private bool automaticDisable;
    [SerializeField, Range(0f, 60f)] private float disableTime;
    [SerializeField] private Item[] requiredItems;
    [SerializeField] private bool consumeRequitedItemsAfterUse;

    private bool isEnabled;

    private Timer automaticDisableTimer;

    private void Start()
    {
        if (automaticDisable)
        {
            automaticDisableTimer = new Timer(disableTime, DisableButton, false);
        }
    }

    public override bool CheckIfLocked()
    {
        if (!playerInventory.HasItems(requiredItems)) { return false; }

        return true;
    }

    protected override void PerformInteraction()
    {
        if (!playerInventory.HasItems(requiredItems)) { return; }

        if (consumeRequitedItemsAfterUse)
        {
            foreach (Item item in requiredItems)
            {
                playerInventory.RemoveItem(item);
            }
        }

        if (disableSwitchAfterActivation)
        {
            enabled = true;
            IsInteractable = false;
        }

        if (!automaticDisable)
        {
            isEnabled = !isEnabled;
        }
        else
        {
            isEnabled = true;
            automaticDisableTimer.Reset();
        }

        if (isEnabled)
        {
            OnActivated.Invoke();
        }
        else
        {
            OnDeactivated.Invoke();
        }
    }

    private void DisableButton()
    {
        isEnabled = false;
        OnDeactivated.Invoke();
    }
}
