using System.Collections;
using UnityEngine;
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

        float time = 0f;
        while (time <= 1f)
        {
            time += Time.deltaTime / fadeDuration;
            blackScreen.color = Color.Lerp(startColor, endColor, time);
            yield return null;
        }

        playerMovement.canMove = true;
        startSequence.Play();
        blackScreen.gameObject.SetActive(false);
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
