using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Sequence : MonoBehaviour
{
    [SerializeField] private SequenceStep[] sequenceSteps;

    [ContextMenu("Play")]
    public void Play()
    {
        StartCoroutine(PlaySequence());
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator PlaySequence()
    {
        foreach (SequenceStep step in sequenceSteps)
        {
            step.OnExecuted?.Invoke();
            yield return new WaitForSeconds(step.pauseTime);
        }
    }

    [System.Serializable]
    public class SequenceStep
    {
        public UnityEvent OnExecuted;
        public float pauseTime;
    }
}
