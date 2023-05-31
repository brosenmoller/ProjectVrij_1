
public class InputManager : Manager
{
    public PlayerActions playerInputActions;
    
    public override void Setup()
    {
        playerInputActions = new PlayerActions();
        playerInputActions.Enable();
    }

    public void DisablePlayerInput()
    {
        playerInputActions.Disable();
    }

    public void EnablePlayerInput()
    {
        playerInputActions.Enable();
    }
}

