using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIView : UIView
{
    [SerializeField] Button playButton;
    [SerializeField] Button settingsButton;
    [SerializeField] Button quitButton;


    public override void Initialize()
    {
        playButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        settingsButton.onClick.AddListener(() => GameManager.UIViewManager.Show(typeof(SettingsUIView), true));
        quitButton.onClick.AddListener(() => Application.Quit());
    }
}
