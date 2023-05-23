using UnityEngine;
using TMPro;

public class PlayerInteractionDetector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiInteractionDescText;
    [SerializeField] private float lookRange = 5f;

    private Camera mainCamera;

    private InteractableObject lastHighlightedInteractableObject = null;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        InteractableObject currentInteractableObject = RaycastForInteractableObject();

        if (lastHighlightedInteractableObject != currentInteractableObject && lastHighlightedInteractableObject != null) 
        {
            lastHighlightedInteractableObject.RemoveHighlight();
            uiInteractionDescText.text = "";
        }

        if (currentInteractableObject != null)
        {
            currentInteractableObject.Highlight();
            uiInteractionDescText.text = currentInteractableObject.interactionDescription;

            if (GameManager.InputManager.playerInputActions.PlayerActionMap.Interact.WasPressedThisFrame())
            {
                currentInteractableObject.OnInteract();
            }

            lastHighlightedInteractableObject = currentInteractableObject;
        }
    }

    private InteractableObject RaycastForInteractableObject()
    {
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out RaycastHit hit, lookRange))
        {
            InteractableObject interactableObject = hit.transform.gameObject.GetComponent<InteractableObject>();

            return interactableObject;
        }

        return null;
    }
}
