using System.Collections.Generic;
using UnityEngine;

/* Base of the PlayerController is from https://sharpcoderblog.com/blog/unity-3d-fps-controller. */

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
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

        if (GameManager.InputManager.playerInputActions.PlayerActionMap.Jump.ReadValue<bool>() && canMove && characterController.isGrounded)
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
}