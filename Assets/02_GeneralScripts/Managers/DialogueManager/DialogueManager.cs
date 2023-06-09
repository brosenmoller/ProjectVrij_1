using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        speakerTMP = GameObject.Find("DialogueSpeaker").GetComponent<TextMeshProUGUI>();
        dialogueTMPA = Object.FindObjectOfType<TMPAnimated>();

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

        bool startDialogue = false;

        if(queuedDialogueText.Count == 0)
        {
            startDialogue = true;
        }

        foreach(AudioObject audioObject in dialogueData.associatedAudio)
        {
            queuedDialogueAudio.Enqueue(audioObject);        
        }

        if (startDialogue)
        {
            StartDialogue();
            PlayQueuedLines();
        }
    }

    private void StartDialogue()
    {
        foreach (string text in queuedDialogueData.Dequeue().dialogueLines)
        {
            queuedDialogueText.Enqueue(text);
        }
    }

    private void PlayQueuedLines()
    {
        if (queuedDialogueText.Count == 0)
        {
            isRunning = false;
            dialogueBoxAnimator.SetBool(DIALOGUE_IS_ACTIVE_PARAMETER, false);
            dialogueTMPA.enabled = false;

        }
        else
        {
            isRunning = true;
            dialogueBoxAnimator.SetBool(DIALOGUE_IS_ACTIVE_PARAMETER, true);
            dialogueTMPA.enabled = true;

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
