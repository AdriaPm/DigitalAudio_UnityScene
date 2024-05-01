using UnityEngine;
using TMPro;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public AudioSource safeMusic;
    public AudioSource dangerMusic;
    public TextMeshProUGUI musicText; // Reference to the TextMeshProUGUI UI element

    public float crossfadeDuration = 2.0f;

    private bool isCrossfading = false;

    void Start()
    {
        UpdateMusicText("Safe"); // Start with "Safe" text
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            Debug.Log("Player entered dangerous area. Switching to danger music.");
            SwitchToDangerMusic();
            UpdateMusicText("Danger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            Debug.Log("Player exited dangerous area. Switching back to safe music.");
            SwitchToSafeMusic();
            UpdateMusicText("Safe");
        }
    }

    private void SwitchToSafeMusic()
    {
        if (!safeMusic.isPlaying)
        {
            if (isCrossfading)
            {
                StopAllCoroutines();
            }
            StartCoroutine(Crossfade(safeMusic, dangerMusic, crossfadeDuration));
        }
    }

    private void SwitchToDangerMusic()
    {
        if (!dangerMusic.isPlaying)
        {
            if (isCrossfading)
            {
                StopAllCoroutines();
            }
            StartCoroutine(Crossfade(dangerMusic, safeMusic, crossfadeDuration));
        }
    }

    IEnumerator Crossfade(AudioSource fadeIn, AudioSource fadeOut, float duration)
    {
        isCrossfading = true;
        float startTime = Time.time;

        fadeIn.volume = 0;
        fadeIn.Play();

        while (fadeIn.volume < 0.5f)
        {
            float elapsedTime = Time.time - startTime;
            float normalizedTime = Mathf.Clamp01(elapsedTime / duration);
            fadeIn.volume = 0.5f * normalizedTime;
            fadeOut.volume = 0.5f * (1.0f - normalizedTime);
            yield return null;
        }

        fadeOut.Stop();
        isCrossfading = false;
    }

    private void UpdateMusicText(string text)
    {
        // Update the TextMeshProUGUI with the provided text
        if (musicText != null)
        {
            musicText.text = text;
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI UI element is not assigned!");
        }
    }
}
