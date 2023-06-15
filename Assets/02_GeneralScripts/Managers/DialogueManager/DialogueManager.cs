using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : Manager
{
    //Bool parameter for the dialogue box animator
    private const string DIALOGUE_IS_ACTIVE_PARAMETER = "dialogueIsActive";

    private TextMeshProUGUI speakerTMP;
    private TMPAnimated dialogueTMPA;
    private Animator dialogueBoxAnimator;

    private Queue<DialogueData> queuedDialogueData = new();

    private Queue<string> queuedDialogueText = new();
    private Queue<AudioObject> queuedDialogueAudio = new();

    private string currentSpeaker;

    public bool isRunning = false;

    public override void Setup()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            speakerTMP = GameObject.Find("DialogueSpeaker").GetComponent<TextMeshProUGUI>();
            speakerTMP.gameObject.SetActive(false);
            dialogueTMPA = Object.FindObjectOfType<TMPAnimated>();
        }

        if(dialogueTMPA != null)
        {
            dialogueBoxAnimator = dialogueTMPA.transform.parent.GetComponent<Animator>();

            //TODO: Unsubscribe from this event
            dialogueTMPA.onDialogueFinish.AddListener(PlayQueuedLines);
        }
    }

    public void QueueDialogue(DialogueData dialogueData)
    {
        queuedDialogueData.Enqueue(dialogueData);

        foreach(AudioObject audioObject in dialogueData.associatedAudio)
        {
            queuedDialogueAudio.Enqueue(audioObject);        
        }

        if(queuedDialogueText.Count <= 0)
        {
            StartDialogue();
        }

    }

    private void StartDialogue()
    {
        DialogueData currentDialogueData = queuedDialogueData.Dequeue();

        foreach (string text in currentDialogueData.dialogueLines)
        {
            queuedDialogueText.Enqueue(text);
        }

        currentSpeaker = currentDialogueData.speakerName;

        PlayQueuedLines();
    }

    private void PlayQueuedLines()
    {
        if (queuedDialogueText.Count == 0)
        {
            isRunning = false;
            dialogueBoxAnimator.SetBool(DIALOGUE_IS_ACTIVE_PARAMETER, false);
            dialogueTMPA.enabled = false;
            speakerTMP.gameObject.SetActive(false);
        }
        else
        {
            isRunning = true;
            dialogueBoxAnimator.SetBool(DIALOGUE_IS_ACTIVE_PARAMETER, true);
            dialogueTMPA.enabled = true;
            speakerTMP.gameObject.SetActive(true);

            NextLine(currentSpeaker, queuedDialogueText.Dequeue());
        }
    }

    private void NextLine(string speaker, string text)
    {
        speakerTMP.text = speaker;
        dialogueTMPA.ReadText(text);
        if (queuedDialogueAudio.Count != 0) { queuedDialogueAudio.Dequeue().Play(); }
    }
}
