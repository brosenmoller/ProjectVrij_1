using UnityEngine;

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
            if(GameManager.InputManager.playerInputActions.PlayerActionMap.Walk.IsPressed())
            {
                Completed();
            }
        }

        else if (completionInput == InputType.OnJump)
        {
            if (GameManager.InputManager.playerInputActions.PlayerActionMap.Jump.IsPressed())
            {
                Completed();
            }
        }

        else if (completionInput == InputType.OnInteract)
        {
            if (GameManager.InputManager.playerInputActions.PlayerActionMap.Interact.IsPressed())
            {
                Completed();
            }
        }

        else if (completionInput == InputType.OnSwitchTime)
        {
            if (GameManager.InputManager.playerInputActions.PlayerActionMap.TimeTravel.IsPressed())
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


