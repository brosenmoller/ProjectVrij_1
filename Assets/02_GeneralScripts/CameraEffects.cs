using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraEffects : MonoBehaviour
{
    public static CameraEffects Instance { get; private set; }

    private CinemachineBrain cameraBrain;

    private void Awake()
    {
        Instance = this;
        cameraBrain = GetComponent<CinemachineBrain>();
    }

    public void EndSequenceCameraShake()
    {
        CameraShake(.4f, .6f, 20);
    }

    public void EndSequenceCameraShakeIntense()
    {
        CameraShake(.4f, .6f, 20);
    }

    public void CameraShake(float intensity, float frequency, float time)
    {
        StartCoroutine(ShakingCamera(intensity, frequency, time));
    }

    private IEnumerator ShakingCamera(float intensity, float frequency, float time)
    {
        CinemachineVirtualCamera camera = cameraBrain.ActiveVirtualCamera as CinemachineVirtualCamera;
        CinemachineBasicMultiChannelPerlin cameraNoise = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cameraNoise.m_AmplitudeGain = intensity;
        cameraNoise.m_FrequencyGain = frequency;

        float shakeTimer = time;

        yield return null;
        while (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            cameraNoise.m_AmplitudeGain = Mathf.Lerp(intensity, 0f, 1 - (shakeTimer / time));
            cameraNoise.m_FrequencyGain = Mathf.Lerp(frequency, 0f, 1 - (shakeTimer / time));
            yield return null;
        }
    }
}
