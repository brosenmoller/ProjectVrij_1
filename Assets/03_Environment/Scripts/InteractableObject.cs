using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class InteractableObject : MonoBehaviour
{
    public string interactionDescription;

    public abstract void Interact();

    public void Highlight()
    {
        //TODO: Code that adds a highlight when player mouse hovered over this item
    }

    public void RemoveHighlight()
    {
        //TODO: Code that disables the highlight
    }

    private void Update()
    {
        RemoveHighlight();
    }
}
