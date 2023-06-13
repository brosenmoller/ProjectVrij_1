using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TimeTravelMechanic : MonoBehaviour
{
    [Header("Rooms")]
    [SerializeField] private Transform world1;
    [SerializeField] private Transform world2;

    [Header("Collision Check Settings")]
    [SerializeField] private float checkHeight;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask notPlayerLayer;

    [Header("Settings")]
    [SerializeField] private bool canTimeTravel = false;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI pastOrFutureText;

    [Header("Effects")]
    [SerializeField] private VolumeProfile postProcessingVolume;
    private LensDistortion postProcessingLensDistortion;
    [SerializeField] private AudioSource timeTravelSound;
    [SerializeField] private float timeTravelDelay;

    private const string PRESENT_TEXT = "1960";
    private const string FUTURE_TEXT = "2020";

    private PlayerMovement playerMovement;

    [HideInInspector] public bool isInPresent;

    public void SetCanTimeTravel(bool state) => canTimeTravel = state;

    private void Awake()
    {
        pastOrFutureText.text = PRESENT_TEXT;
        playerMovement = GetComponent<PlayerMovement>();

        if (postProcessingVolume.TryGet(out LensDistortion lensDistortion))
        {
            postProcessingLensDistortion = lensDistortion;
        }
    }

    private void OnEnable()
    {
        GameManager.InputManager.playerInputActions.PlayerActionMap.TimeTravel.performed += TimeTravelPerformed;
    }

    private void OnDisable()
    {
        GameManager.InputManager.playerInputActions.PlayerActionMap.TimeTravel.performed -= TimeTravelPerformed;
    }

    private void TimeTravelPerformed(InputAction.CallbackContext callbackContext)
    {
        if (!canTimeTravel) { return; }
        ToggleWorld();
    }

    public void ToggleWorld()
    {
        Transform currentWorld = transform.parent;

        if (currentWorld == world1) { SwitchWorld(world2); }
        else { SwitchWorld(world1); }
    }

    private void SwitchWorld(Transform targetWorld)
    {
        Vector3 playerRelativePosition = transform.localPosition;

        if (!Physics.CheckSphere(targetWorld.position + playerRelativePosition + Vector3.up * checkHeight, checkRadius, notPlayerLayer, QueryTriggerInteraction.Ignore))
        {
            StartCoroutine(TimeTravelEffect(targetWorld));
        }
        else
        {
            Debug.Log("Can't switch now");
        }
    }

    private IEnumerator TimeTravelEffect(Transform targetWorld)
    {
        canTimeTravel = false;

        timeTravelSound.Play();

        float time = 0f;

        while (time <= 1f)
        {
            time += Time.deltaTime / timeTravelDelay;
            postProcessingLensDistortion.intensity.overrideState = true;
            postProcessingLensDistortion.scale.overrideState = true;
            postProcessingLensDistortion.intensity.value = Mathf.Lerp(0, -1, time);
            postProcessingLensDistortion.scale.value = Mathf.Lerp(1, .5f, time);

            yield return null;
        }

        Vector3 relativePosition = transform.localPosition;
        transform.parent = targetWorld;
        playerMovement.WarpPlayer(targetWorld.position + relativePosition);

        if (targetWorld == world1)
        {
            pastOrFutureText.text = PRESENT_TEXT;
            isInPresent = true;
        }
        else
        {
            pastOrFutureText.text = FUTURE_TEXT;
            isInPresent = false;
        }

        time = 0f;

        while (time <= 1f)
        {
            time += Time.deltaTime / timeTravelDelay;
            postProcessingLensDistortion.intensity.overrideState = true;
            postProcessingLensDistortion.scale.overrideState = true;
            postProcessingLensDistortion.intensity.value = Mathf.Lerp(-1, 0, time);
            postProcessingLensDistortion.scale.value = Mathf.Lerp(.5f, 1, time);

            yield return null;
        }

        canTimeTravel = true;
    }

    private void OnDrawGizmos()
    {
        if (world1 == null || world2 == null) { return; }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(world1.position + transform.localPosition + Vector3.up * checkHeight, checkRadius);
        Gizmos.DrawWireSphere(world2.position + transform.localPosition + Vector3.up * checkHeight, checkRadius);
    }
}
