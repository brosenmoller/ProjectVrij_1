using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialManager : Manager
{
    private Queue<TutorialStep> queuedTutorialSteps = new();

    private GameObject tutorialPanel;
    private TextMeshProUGUI titleText;
    private TextMeshProUGUI descriptionText;

    private bool isShowingTutorial;
    private TutorialStep currentStep;

    private const string TITLE_TEXT_NAME = "TutorialTitle";
    private const string DESC_TEXT_NAME = "TutorialDesc";

    public override void OnFixedUpdate()
    {
        currentStep?.FixedUpdate();
    }

    public override void OnSceneLoad()
    {
        //Bad implementation ahead :c

        if (SceneManager.GetActiveScene().name.Equals("FinalScene"))
        {
            titleText = GameObject.Find(TITLE_TEXT_NAME).GetComponent<TextMeshProUGUI>();
            descriptionText = GameObject.Find(DESC_TEXT_NAME).GetComponent<TextMeshProUGUI>();

            tutorialPanel = titleText.transform.parent.gameObject;
            HideTutorialUI();
        }
    }

    public void QueueTutorial(TutorialStep tutorialStep)
    {
        queuedTutorialSteps.Enqueue(tutorialStep);

        if(!isShowingTutorial)
        {
            StartTutorial();
        }
    }

    public void StartTutorial()
    {
        TutorialStep tutorialStep = queuedTutorialSteps.Dequeue();
        currentStep = tutorialStep;

        titleText.text = tutorialStep.stepTitle;
        descriptionText.text = tutorialStep.stepDescription;

        isShowingTutorial = true;
        ShowTutorialUI();
    }

    public void FinishTutorial()
    {
        currentStep = null;

        if(queuedTutorialSteps.Count > 0)
        {
            StartTutorial();
        }
        else
        {
            isShowingTutorial = false;
            HideTutorialUI();
        }
    }

    private void HideTutorialUI()
    {
        tutorialPanel?.SetActive(false);
    }

    private void ShowTutorialUI()
    {
        tutorialPanel?.SetActive(true);
    }
}
