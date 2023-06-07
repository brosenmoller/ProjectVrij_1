using UnityEngine;
using TMPro;

public class PlayerInteractionDetector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiInteractionDescText;
    [SerializeField] private TextMeshProUGUI uiBlockDescText;
    [SerializeField] private float lookRange = 5f;
    [SerializeField] private bool canInteract = true;

    public void SetCanInteract(bool value) => canInteract = value;
    public bool GetCanInteract() => canInteract;

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
            uiBlockDescText.text = "";
        }

        if (currentInteractableObject != null)
        {
            if (!currentInteractableObject.IsInteractable || !canInteract)
            {
                uiInteractionDescText.text = "";
                uiBlockDescText.text = "";
                currentInteractableObject.RemoveHighlight();
                return;
            }

            currentInteractableObject.Highlight();
            lastHighlightedInteractableObject = currentInteractableObject;

            if (!currentInteractableObject.CheckIfLocked())
            {
                uiBlockDescText.text = currentInteractableObject.lockedDescription;
                uiInteractionDescText.text = "";
                return;
            }

            uiBlockDescText.text = "";
            uiInteractionDescText.text = currentInteractableObject.interactionDescription;

            if (GameManager.InputManager.playerInputActions.PlayerActionMap.Interact.WasPressedThisFrame())
            {
                currentInteractableObject.OnInteract();
            }
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
