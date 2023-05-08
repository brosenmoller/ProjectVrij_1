using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Outline))]
public abstract class InteractableObject : MonoBehaviour
{
    public string interactionDescription;

    private Outline outline;

    public abstract void Interact();

    private void Start()
    {
        outline = GetComponent<Outline>();
    }

    public void Highlight()
    {
        outline.enabled = true;
    }

    public void RemoveHighlight()
    {
        outline.enabled = false;
    }

    private void Update()
    {
        RemoveHighlight();
    }
}
