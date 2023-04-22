
public class InputManager : Manager
{
    public PlayerActions playerInputActions;
    
    public override void Setup()
    {
        playerInputActions = new PlayerActions();
        playerInputActions.Enable();
    }
}

