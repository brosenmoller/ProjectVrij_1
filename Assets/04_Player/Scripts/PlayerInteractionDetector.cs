using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionDetector : MonoBehaviour
{
    public TMPro.TextMeshProUGUI uiInteractionDescText;

    [SerializeField] private float  lookRange = 5f;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameManager.InputManager.playerInputActions.PlayerActionMap.Interact.WasPressedThisFrame())
        {
            RaycastForInteractableObject()?.Interact();
        }
        else
        {
            InteractableObject currentInteractableObject = RaycastForInteractableObject();
            currentInteractableObject?.Highlight();
            uiInteractionDescText.text = currentInteractableObject?.interactionDescription;
        }
    }

    private InteractableObject RaycastForInteractableObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, lookRange))
        {
            InteractableObject interactableObject = hit.transform.gameObject.GetComponent<InteractableObject>();

            return interactableObject;
        }

        return null;
    }
}
