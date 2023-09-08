using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorEndSequence : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] private Sequence repairSequence1;
    [SerializeField] private Sequence repairSequence2;
    [SerializeField] private Sequence destroySequence1;
    [SerializeField] private Sequence destroySequence2;

    [Header("References")]
    [SerializeField] private CinemachineVirtualCamera endSequenceCamera;
    [SerializeField] private Button destroyButton;
    [SerializeField] private Button repairButton;
    [SerializeField] private Transform UIParent;

    [Header("Sounds")]
    [SerializeField] private AudioObject explosionSound;
    [SerializeField] private AudioObject valveSound;

    private PlayerMovement playerMovement;

    private bool hasRepaired = false;
    private bool hasDestroyed = false;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        destroyButton.onClick.AddListener(Destroy);
        repairButton.onClick.AddListener(Repair);
    }

    public void StartSequence()
    {
        playerMovement.canMove = false;
        endSequenceCamera.Priority = 10;
        Invoke(nameof(Sequence), 2f);
    }

    public void Sequence()
    {
        GameManager.UIViewManager.Show(typeof(GameEndSequenceUIView));
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Destroy()
    {
        if (!hasDestroyed)
        {
            hasDestroyed = true;
            StartCoroutine(RotateValve(25, true, 360 * 4));
            destroySequence1.Play();
        }
        else
        {
            destroySequence2.Play();
        }
    }

    public void Repair()
    {
        if (!hasRepaired)
        {
            hasRepaired = true;
            StartCoroutine(RotateValve(26, false, 360 * 4));
            repairSequence1.Play();
        }
        else
        {
            repairSequence2.Play();
        }
    }

    private IEnumerator RotateValve(float duration, bool directionRight, float rotationAmount)
    {
        float startRotation = transform.position.x;
        float endRotation = startRotation + (directionRight ? rotationAmount : -rotationAmount);

        UIParent.gameObject.SetActive(false);

        valveSound.Play();
        float jitterFactor = 3f; // Adjust the jitter range as needed
        float time = 0f;
        while (time < 1f)
        {
            //time += Time.deltaTime / duration;

            float jitter = Random.Range(1f - jitterFactor, 1f + jitterFactor); // Random jitter factor
            time += (Time.deltaTime / duration) * jitter; // Apply the jitter to the time incrementation

            transform.rotation = Quaternion.Euler(Mathf.Lerp(startRotation, endRotation, time), 0, 90);
            yield return null;
        }

        valveSound.Stop();

        UIParent.gameObject.SetActive(true);
    }
}
