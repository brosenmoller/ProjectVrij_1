using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : InteractableObject
{
    [Header("Button Settings")]
    [SerializeField] bool automaticDisable;
    [SerializeField] bool disableSwitchAfterActivation;
    [SerializeField] float disableTime;
    [SerializeField] List<Item> requiredItems;

    public override void Interact()
    {
        Debug.Log("Interacted with " + this.name);
    }
}
