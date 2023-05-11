using UnityEngine;
using TMPro;

public class PlayerInteractionDetector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiInteractionDescText;
    [SerializeField] private float lookRange = 5f;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        if (GameManager.InputManager.playerInputActions.PlayerActionMap.Interact.WasPressedThisFrame())
        {
            InteractableObject currentInteractableObject = RaycastForInteractableObject();
            
            if (currentInteractableObject != null)
            {
                currentInteractableObject.Interact();
            }
        }
        else
        {
            InteractableObject currentInteractableObject = RaycastForInteractableObject();

            if (currentInteractableObject != null)
            {
                currentInteractableObject.Highlight();
                uiInteractionDescText.text = currentInteractableObject.interactionDescription;
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
