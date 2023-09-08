using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIView : UIView
{
    [SerializeField] private Image blackScreen;
    [SerializeField] private float fadeDuration;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Sequence startSequence;

    public override void Initialize()
    {
        GameManager.Instance.StartCoroutine(FadeBlackScreen());
    }
        
    private IEnumerator FadeBlackScreen()
    {
        Color startColor = blackScreen.color;
        Color endColor = Color.clear;

        bool hasStartedGame = false;

        float time = 0f;
        while (time <= 1f)
        {
            time += Time.deltaTime / fadeDuration;
            blackScreen.color = Color.Lerp(startColor, endColor, time);

            if (time >= .7f && !hasStartedGame)
            {
                hasStartedGame = true;
                startSequence.Play();
                playerMovement.canMove = true;
            }

            yield return null;
        }
        
        blackScreen.gameObject.SetActive(false);
    }

    public void StartFadeInBlackScreen()
    {
        StartCoroutine(FadeInBlackScreen());
    }

    private IEnumerator FadeInBlackScreen()
    {
        Color startColor = Color.clear;
        Color endColor = Color.black;

        blackScreen.gameObject.SetActive(true);

        float time = 0f;
        while (time <= 1f)
        {
            time += Time.deltaTime / fadeDuration;
            blackScreen.color = Color.Lerp(startColor, endColor, time);

            yield return null;
        }
    }

    //public override void Initialize()
    //{
    //    GameManager.InputManager.playerInputActions.PlayerActionMap.Pause.performed += ctx => OpenPauseMenu();
    //}

    //private void OnDisable()
    //{
    //    GameManager.InputManager.playerInputActions.PlayerActionMap.Pause.performed -= ctx => OpenPauseMenu();
    //}

    //private void OpenPauseMenu()
    //{
    //    Time.timeScale = 0;
    //    Cursor.lockState = CursorLockMode.None;
    //    Cursor.visible = true;
    //    GameManager.InputManager.DisablePlayerInput();
    //    GameManager.UIViewManager.Show(typeof(GamePauseUIView));
    //}
}
