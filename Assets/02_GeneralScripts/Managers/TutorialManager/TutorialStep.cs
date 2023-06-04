using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class TutorialStep : ScriptableObject
{
    [Header("Tutorial step settings")]

    public string stepTitle;
    [TextArea] public string stepDescription;

    private enum InputType
    {
        OnMove = 0,
        OnJump = 1,
        OnInteract = 2,
        OnSwitchTime = 3,
    }

    [SerializeField] private InputType completionInput;

    public void FixedUpdate()
    {
        if (completionInput == InputType.OnMove)
        {
            if(GameManager.InputManager.playerInputActions.PlayerActionMap.Walk.WasPerformedThisFrame())
            {
                Completed();
            }
        }

        else if (completionInput == InputType.OnJump)
        {
            if (GameManager.InputManager.playerInputActions.PlayerActionMap.Jump.WasPerformedThisFrame())
            {
                Completed();
            }
        }

        else if (completionInput == InputType.OnInteract)
        {
            if (GameManager.InputManager.playerInputActions.PlayerActionMap.Interact.WasPerformedThisFrame())
            {
                Completed();
            }
        }

        else if (completionInput == InputType.OnSwitchTime)
        {
            if (GameManager.InputManager.playerInputActions.PlayerActionMap.TimeTravel.WasPerformedThisFrame())
            {
                Completed();
            }
        }
    }

    private void Completed()
    {
        GameManager.TutorialManager.FinishTutorial();
    }
}


