using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : Manager
{
    private TMPAnimated dialogueTMPA;

    private Queue<string> queuedDialogueData = new();

    public override void Setup()
    {
        dialogueTMPA = GameManager.FindObjectOfType<TMPAnimated>();

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
        if (queuedDialogueData.Count == 0) { return; }
        dialogueTMPA.ReadText(queuedDialogueData.Dequeue());
    }
}
