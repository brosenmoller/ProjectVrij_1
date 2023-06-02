using UnityEngine;
using System.Collections;

public class Sequence : MonoBehaviour
{
    [SerializeField] private bool playOnAwake = false;
    public SequenceStep[] sequenceSteps;

    private TimeTravelMechanic timeTravelMechanic;
    private PlayerInventory playerInventory;

    private void Awake()
    {
        if (playOnAwake) { Play(); }
        timeTravelMechanic = FindObjectOfType<TimeTravelMechanic>();
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    [ContextMenu("Play")]
    public void Play()
    {
        StartCoroutine(ExecuteSequence(this));
    }

    [ContextMenu("Stop")]
    public void Stop()
    {
        StopAllCoroutines();
    }

    private bool CheckConditions(SequenceCondition[] conditions)
    {
        foreach(SequenceCondition condition in conditions)
        {
            switch (condition)
            {
                case SequenceCondition.IsInPresent:
                    if (!timeTravelMechanic.isInPresent) { return false; }
                    break;
                case SequenceCondition.IsInFuture:
                    if (timeTravelMechanic.isInPresent) { return false; }
                    break;
                case SequenceCondition.DialogueNotRunning:
                    if (GameManager.DialogueManager.IsRunning) { return false; }
                    break;
            }
        }

        return true;
    }

    public IEnumerator ExecuteSequence(Sequence sequence)
    {
        foreach (SequenceStep step in sequence.sequenceSteps)
        {
            yield return new WaitForSeconds(step.delayBeforeConditions);
            yield return new WaitUntil(() => CheckConditions(step.conditions));
            yield return new WaitUntil(() => playerInventory.HasItems(step.requiredItems));
            
            if (step.requiredCollider != null)
            {
                yield return new WaitUntil(() => step.requiredCollider.bounds.Contains(timeTravelMechanic.transform.position));
            }

            yield return new WaitForSeconds(step.delayAfterConditions);

            step.OnExecuted?.Invoke();
        }
    }
}
