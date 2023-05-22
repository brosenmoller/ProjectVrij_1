using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : Manager
{
    private TMPAnimated dialogueTMPA;
    private Animator dialogueBoxAnimator;
    private const string dialogueIsActiveParameter = "dialogueIsActive";

    private Queue<string> queuedDialogueData = new();

    public override void Setup()
    {
        dialogueTMPA = GameManager.FindObjectOfType<TMPAnimated>();
        dialogueBoxAnimator = dialogueTMPA.transform.parent.GetComponent<Animator>();

        //TODO: Unsubscribe from this event
        dialogueTMPA.onDialogueFinish.AddListener(StartDialogue);
    }

    public void QueueDialogue(DialogueData dialogueData)
    {
        bool startDialogue = false;

        if(queuedDialogueData.Count == 0)
        {
            startDialogue = true;
        }

        foreach(string text in dialogueData.dialogueLines)
        {
            queuedDialogueData.Enqueue(text);
        }

        if (startDialogue)
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        if (queuedDialogueData.Count == 0) 
        {
            dialogueBoxAnimator.SetBool(dialogueIsActiveParameter, false);
            dialogueTMPA.enabled = false;
        }
        else
        {
            dialogueBoxAnimator.SetBool(dialogueIsActiveParameter, true);
            dialogueTMPA.enabled = true;
            dialogueTMPA.ReadText(queuedDialogueData.Dequeue());
        }
    }
}
