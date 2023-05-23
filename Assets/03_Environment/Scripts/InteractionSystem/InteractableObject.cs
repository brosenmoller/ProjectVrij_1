using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Outline))]
public abstract class InteractableObject : MonoBehaviour
{
    [Header("Base Interactable Object Settings")]
    public string interactionDescription;
    [SerializeField] protected bool _isInteractable = true;

    protected bool IsInteractable {
        set { 
            _isInteractable = value;
            if (!_isInteractable) { outline.enabled = false; } 
        }
        get { return _isInteractable; }
    }

    private Outline outline;
    protected PlayerInventory playerInventory;

    public void OnInteract()
    {
        if (IsInteractable)
        {
            PerformInteraction();
        }
    }

    protected abstract void PerformInteraction();

    private void Awake()
    {
        outline = GetComponent<Outline>();
        playerInventory = FindObjectOfType<PlayerInventory>();
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
