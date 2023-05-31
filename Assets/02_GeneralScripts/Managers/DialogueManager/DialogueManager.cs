using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : Manager
{
    //Bool parameter for the dialogue box animator
    private const string DIALOGUE_IS_ACTIVE_PARAMETER = "dialogueIsActive";

    private TMPAnimated dialogueTMPA;
    private Animator dialogueBoxAnimator;

    private Queue<string> queuedDialogueText = new();
    private Queue<AudioObject> queuedDialogueAudio = new();

    public override void Setup()
    {
        dialogueTMPA = Object.FindObjectOfType<TMPAnimated>();

        if(dialogueTMPA != null)
        {
            dialogueBoxAnimator = dialogueTMPA.transform.parent.GetComponent<Animator>();

            //TODO: Unsubscribe from this event
            dialogueTMPA.onDialogueFinish.AddListener(StartDialogue);
        }
    }

    public void QueueDialogue(DialogueData dialogueData)
    {
        bool startDialogue = false;

        if(queuedDialogueText.Count == 0)
        {
            startDialogue = true;
        }

        foreach(string text in dialogueData.dialogueLines)
        {
            queuedDialogueText.Enqueue(text);
        }

        foreach(AudioObject audioObject in dialogueData.associatedAudio)
        {
            queuedDialogueAudio.Enqueue(audioObject);        
        }

        if (startDialogue)
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        if (queuedDialogueText.Count == 0) 
        {
            dialogueBoxAnimator.SetBool(DIALOGUE_IS_ACTIVE_PARAMETER, false);
            dialogueTMPA.enabled = false;
        }
        else
        {
            dialogueBoxAnimator.SetBool(DIALOGUE_IS_ACTIVE_PARAMETER, true);
            dialogueTMPA.enabled = true;
            dialogueTMPA.ReadText(queuedDialogueText.Dequeue());
            if (queuedDialogueAudio.Count != 0) { queuedDialogueAudio.Dequeue().Play(); }
        }
    }
}
