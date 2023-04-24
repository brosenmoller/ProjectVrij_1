using UnityEngine;

/* Base of the PlayerController is from https://sharpcoderblog.com/blog/unity-3d-fps-controller.
 * Edited for use of this project. */

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkingSpeed = 7.5f;
    [SerializeField] private float runningSpeed = 11.5f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float lookSpeed = 2.0f;
    [SerializeField] private float lookXLimit = 45.0f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    [HideInInspector] public bool canMove = true;

    private Vector3 warpLocation;
    private bool warpThisFrame;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        Vector2 inputDirection = GameManager.InputManager.playerInputActions.PlayerActionMap.Walk.ReadValue<Vector2>();

        // Press Left Shift to run
        bool isRunning = GameManager.InputManager.playerInputActions.PlayerActionMap.Sprint.ReadValue<bool>();
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * inputDirection.y : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * inputDirection.x : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (GameManager.InputManager.playerInputActions.PlayerActionMap.Jump.WasPressedThisFrame() && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -GameManager.InputManager.playerInputActions.PlayerActionMap.MoveCameraY.ReadValue<float>() * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, GameManager.InputManager.playerInputActions.PlayerActionMap.MoveCameraX.ReadValue<float>() * lookSpeed, 0);
        }
    }

    public void WarpPlayer(Vector3 warpLocation)
    {
        this.warpLocation = warpLocation;
        warpThisFrame = true;
    }

    private void LateUpdate()
    {
        if (warpThisFrame)
        {
            warpThisFrame = false;
            transform.position = warpLocation;
        }
    }
}