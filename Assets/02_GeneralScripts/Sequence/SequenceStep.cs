using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class SequenceStep
{
    public float delayBeforeConditions;
    public SequenceCondition[] conditions;
    public Item[] requiredItems;
    public BoxCollider requiredCollider;
    public float delayAfterConditions;
    public UnityEvent OnExecuted;

}

public enum SequenceCondition
{
    IsInPresent = 0,
    IsInFuture = 1,
    DialogueNotRunning = 2,
}