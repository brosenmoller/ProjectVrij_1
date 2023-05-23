using UnityEngine;
using UnityEngine.Events;

public class Button : InteractableObject
{
    [Header("Button Settings")]
    [SerializeField] private UnityEvent OnActivated;
    [SerializeField] private UnityEvent OnDeactivated;

    [Header("Extra Settings")]
    [SerializeField] private bool disableSwitchAfterActivation;

    [SerializeField] private bool automaticDisable;
    [SerializeField, Range(0f, 60f)] private float disableTime;
    [SerializeField] private Item[] requiredItems;

    private bool isEnabled;

    private Timer automaticDisableTimer;

    private void Start()
    {
        if (automaticDisable)
        {
            automaticDisableTimer = new Timer(disableTime, DisableButton, false);
        }
    }

    protected override void PerformInteraction()
    {
        if (!playerInventory.HasItems(requiredItems)) { return; }

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
