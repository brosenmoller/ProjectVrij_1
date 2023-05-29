using UnityEngine;
using UnityEngine.InputSystem;

public class GameUIView : UIView
{
    public override void Initialize()
    {
        GameManager.InputManager.playerInputActions.PlayerActionMap.Pause.performed += ctx => OpenPauseMenu();
    }

    private void OnDestroy()
    {
        GameManager.InputManager.playerInputActions.PlayerActionMap.Pause.performed -= ctx => OpenPauseMenu();
    }

    private void OpenPauseMenu()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameManager.InputManager.DisablePlayerInput();
        GameManager.UIViewManager.Show(typeof(GamePauseUIView));
    }
}
