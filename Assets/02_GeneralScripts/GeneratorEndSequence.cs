using Cinemachine;
using UnityEngine;

public class GeneratorEndSequence : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CinemachineVirtualCamera endSequenceCamera;

    [Header("Sounds")]
    [SerializeField] private AudioObject explosionSound;
    [SerializeField] private AudioObject ValveSound;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void StartSequence()
    {
        playerMovement.canMove = false;
        endSequenceCamera.Priority = 10;

    }
}
