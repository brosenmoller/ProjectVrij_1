using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePauseUIView : UIView
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button returnToMenuButton;

    private const string MAIN_MENU_SCENE = "MainMenu";

    public override void Initialize()
    {
        resumeButton.onClick.AddListener(() => ResumeGame());
        returnToMenuButton.onClick.AddListener(() => ReturnToMenu());
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.InputManager.EnablePlayerInput();
        GameManager.UIViewManager.Show(typeof(GameUIView));
    }

    private void ReturnToMenu()
    {
        ResumeGame();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(MAIN_MENU_SCENE);
    }
}
