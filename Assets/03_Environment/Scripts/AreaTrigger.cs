using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class AreaTrigger : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent OnEntered;
    [SerializeField] private UnityEvent OnExited;

    [Header("Settings")]
    [SerializeField] private bool disableAfterActivation = true;

    private bool disabled = false;

#if UNITY_EDITOR
    private void Awake()
    {
        Collider collider = GetComponent<Collider>();
        if (!collider.isTrigger)
        {
            Debug.LogWarning("The GameObject: \"" + gameObject.name + "\" has an area trigger component but doesn't have a trigger collider");
        }
    }
#endif

    private void OnTriggerEnter(Collider other)
    {
        if (disabled) { return; }

        if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            OnEntered?.Invoke();

            if (disableAfterActivation) { disabled = true; }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (disabled) { return; }

        if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            OnExited?.Invoke();
        }
    }
}
