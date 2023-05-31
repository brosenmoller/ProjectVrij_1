using TMPro;
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

    [Header("References")]
    [SerializeField] private TextMeshProUGUI pastOrFutureText;

    private const string PRESENT_TEXT = "Present";
    private const string FUTURE_TEXT = "Future";

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

        if (!Physics.CheckSphere(targetWorld.position + playerRelativePosition + Vector3.up * checkHeight, checkRadius, notPlayerLayer))
        {
            transform.parent = targetWorld;
            playerMovement.WarpPlayer(targetWorld.position + playerRelativePosition);

            if (targetWorld ==  world1) { pastOrFutureText.text = PRESENT_TEXT; }
            else { pastOrFutureText.text = FUTURE_TEXT; }
        }
        else
        {
            Debug.Log("Can't switch now");
        }
    }

    private void OnDrawGizmos()
    {
        if (world1 == null || world2 == null) { return; }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(world1.position + transform.localPosition + Vector3.up * checkHeight, checkRadius);
        Gizmos.DrawWireSphere(world2.position + transform.localPosition + Vector3.up * checkHeight, checkRadius);
    }
}
