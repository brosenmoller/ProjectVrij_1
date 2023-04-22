using System;
using UnityEngine;
using System.Collections;

public class AudioManager : Manager
{
    public IEnumerator FadingSound(AudioSource audioSource, float targetVolume, float fadeDuration, Action onComplete = null)
    {
        float elapsedTime = 0;
        float startVolume = audioSource.volume;

        while (elapsedTime <= fadeDuration)
        {
            float newVolume = Mathf.Lerp(startVolume, targetVolume, Mathf.Pow(elapsedTime / fadeDuration, 2));

            audioSource.volume = newVolume;

            yield return null;

            elapsedTime += Time.deltaTime;
        }

        if (audioSource.volume < 0.01f) audioSource.Stop();
        onComplete?.Invoke();
    }
}
