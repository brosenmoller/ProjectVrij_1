using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class FootStepAudio : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float walkingDelay;
    [SerializeField] private float runningDelay;
    [SerializeField] private float delayMaxDeviation;
    [SerializeField] private float maxPitchDeviation;

    [Header("References")]
    [SerializeField] private PlayerMovement playerMovement;

    [Header("Sounds")]
    [SerializeField] private AudioClip[] footStepSounds;
    
    private AudioSource audioSource;

    private float currentDelay = 0;
    private int currentIndex = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!playerMovement.IsMoving) { return; }

        if (currentDelay > Time.time) { return; }

        audioSource.clip = footStepSounds[currentIndex];
        audioSource.pitch = 1f + Random.Range(-maxPitchDeviation, maxPitchDeviation);
        audioSource.Play();

        currentIndex++;
        if (currentIndex >= footStepSounds.Length) { currentIndex = 0; }

        if (playerMovement.IsSprinting)
        {
            currentDelay = Time.time + runningDelay + Random.Range(-delayMaxDeviation, delayMaxDeviation);
        }
        else
        {
            currentDelay = Time.time + walkingDelay + Random.Range(-delayMaxDeviation, delayMaxDeviation);
        }
    }
}
