using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Outline))]
public abstract class InteractableObject : MonoBehaviour
{
    public string interactionDescription;

    private Outline outline;
    protected PlayerInventory playerInventory;

    public abstract void Interact();

    private void Awake()
    {
        outline = GetComponent<Outline>();
        playerInventory = FindObjectOfType<PlayerInventory>();
        RemoveHighlight();
    }

    public void Highlight()
    {
        outline.enabled = true;
    }

    public void RemoveHighlight()
    {
        outline.enabled = false;
    }
}
