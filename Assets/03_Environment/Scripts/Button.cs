using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Button : InteractableObject
{
    [Header("Button Settings")]
    public UnityEvent OnActivated;
    public UnityEvent OnDeactivated;

    [Header("Extra Settings")]
    [SerializeField] bool disableSwitchAfterActivation;

    [SerializeField] bool automaticDisable;
    [Range(0f, 60f)] [SerializeField] float disableTime;
    [SerializeField] List<Item> requiredItems;

    private bool isEnabled;
    private bool interactable = true;

    public override void Interact()
    {
        //if(!PlayerInventory.Contains(requiredItems)
        //{
        //  return;
        //}
        if (!interactable)
        {
            return;
        }

        if (disableSwitchAfterActivation)
        {
            enabled = true;
            interactable = false;
        }

        if (!automaticDisable)
        {
            isEnabled = !isEnabled;
        }
        else
        {
            isEnabled = true;
            StartCoroutine(disableButtonAfterTime(disableTime));
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

    private IEnumerator disableButtonAfterTime(float timeToDisable)
    {
        yield return new WaitForSeconds(timeToDisable);

        isEnabled = false;
        OnDeactivated.Invoke();
    }
}
