using UnityEngine;
using UnityEngine.InputSystem;

public class TimeTravelMechanic : MonoBehaviour
{
    [Header("Rooms")]
    [SerializeField] private Transform world1;
    [SerializeField] private Transform world2;

    [Header("Collision Check Settings")]
    [SerializeField] private float checkHeight;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask notPlayerLayer;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        GameManager.InputManager.playerInputActions.PlayerActionMap.TimeTravel.performed += TimeTravelPerformed;
    }

    private void OnDisable()
    {
        GameManager.InputManager.playerInputActions.PlayerActionMap.TimeTravel.performed -= TimeTravelPerformed;
    }

    private void TimeTravelPerformed(InputAction.CallbackContext callbackContext)
    {
        Transform currentWorld = transform.parent;

        if (currentWorld == world1) { SwitchWorld(world2); }
        else { SwitchWorld(world1); }
    }

    private void SwitchWorld(Transform targetWorld)
    {
        Vector3 playerRelativePosition = transform.localPosition;

        if (Physics.CheckSphere(targetWorld.position + playerRelativePosition + Vector3.up * checkHeight, checkRadius, notPlayerLayer))
        {
            // Maybe we want some code here to find a valid location nearby, but I just disallow it for now
            Debug.Log("Can't switch now");
        }
        else
        {
            transform.parent = targetWorld;
            playerMovement.WarpPlayer(targetWorld.position + playerRelativePosition);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(world1.position + transform.localPosition + Vector3.up * checkHeight, checkRadius);
        Gizmos.DrawWireSphere(world2.position + transform.localPosition + Vector3.up * checkHeight, checkRadius);
    }
}
