using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Outline))]
public abstract class InteractableObject : MonoBehaviour
{
    [Header("Base Interactable Object Settings")]
    public string interactionDescription;
    public string lockedDescription;
    [SerializeField] protected bool _isInteractable = true;

    public bool IsInteractable {
        set { 
            _isInteractable = value;
            if (!_isInteractable) { outline.enabled = false; } 
        }
        get { return _isInteractable; }
    }

    private Outline outline;
    protected PlayerInventory playerInventory;
    protected PlayerInteractionDetector playerInteractionDetector;

    public void OnInteract()
    {
        if (IsInteractable)
        {
            PerformInteraction();
        }
    }

    public virtual bool CheckIfLocked()
    {
        return true;
    }

    protected abstract void PerformInteraction();

    private void Awake()
    {
        outline = GetComponent<Outline>();
        if (!IsInteractable) { outline.enabled = false; }

        playerInventory = FindObjectOfType<PlayerInventory>();
        playerInteractionDetector = playerInventory.gameObject.GetComponent<PlayerInteractionDetector>();
        RemoveHighlight();
    }

    public void Highlight()
    {
        if (IsInteractable)
        {
            outline.enabled = true;
        }
    }

    public void RemoveHighlight()
    {
        if (IsInteractable)
        {
            outline.enabled = false;
        }
    }

    public void SetInteractableState(bool state)
    {
        IsInteractable = state;
    }
}
