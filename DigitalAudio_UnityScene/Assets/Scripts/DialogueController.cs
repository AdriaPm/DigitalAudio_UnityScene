using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class SoundController : MonoBehaviour
{
    [System.Serializable]
    public class SoundSource
    {
        public AudioSource audioSource;
        [HideInInspector]
        public float originalVolume;
        public float lowerAmount = 0.1f;
        public float raiseAmount = 0.1f;
    }

    public SoundSource[] soundSources;
    public float changeDuration = 1.0f;

    private Coroutine volumeChangeCoroutine;

    void Start()
    {
        // Save original volume for each sound source
        for (int i = 0; i < soundSources.Length; i++)
        {
            soundSources[i].originalVolume = soundSources[i].audioSource.volume;
        }
    }

    public void LowerVolume()
    {
        LowerVolumeForAll(soundSources[0].lowerAmount);
    }

    public void RaiseVolume()
    {
        RaiseVolumeForAll(soundSources[0].raiseAmount);
    }

    public void LowerVolume(float amount)
    {
        LowerVolumeForAll(amount);
    }

    public void RaiseVolume(float amount)
    {
        RaiseVolumeForAll(amount);
    }

    public void RestoreOriginalVolume()
    {
        if (volumeChangeCoroutine != null)
            StopCoroutine(volumeChangeCoroutine);

        for (int i = 0; i < soundSources.Length; i++)
        {
            soundSources[i].audioSource.volume = soundSources[i].originalVolume;
        }
    }

    private void LowerVolumeForAll(float amount)
    {
        if (volumeChangeCoroutine != null)
            StopCoroutine(volumeChangeCoroutine);

        volumeChangeCoroutine = StartCoroutine(ChangeVolumeForAll(-amount));
    }

    private void RaiseVolumeForAll(float amount)
    {
        if (volumeChangeCoroutine != null)
            StopCoroutine(volumeChangeCoroutine);

        volumeChangeCoroutine = StartCoroutine(ChangeVolumeForAll(amount));
    }

    private IEnumerator ChangeVolumeForAll(float amount)
    {
        float[] startVolumes = new float[soundSources.Length];
        float[] targetVolumes = new float[soundSources.Length];

        for (int i = 0; i < soundSources.Length; i++)
        {
            startVolumes[i] = soundSources[i].audioSource.volume;
            targetVolumes[i] = Mathf.Clamp01(startVolumes[i] + amount);
        }

        float elapsedTime = 0;

        while (elapsedTime < changeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / changeDuration);

            for (int i = 0; i < soundSources.Length; i++)
            {
                float newVolume = Mathf.Lerp(startVolumes[i], targetVolumes[i], t);
                soundSources[i].audioSource.volume = newVolume;
            }

            yield return null;
        }
    }
}
