using UnityEngine;
using TMPro;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public AudioSource safeMusic;
    public AudioSource dangerMusic;
    public AudioSource tavernMusic;
    public TextMeshProUGUI musicText;

    public float crossfadeDuration = 2.0f;

    private bool isCrossfading = false;
    private bool isInTavern = false;

    void Start()
    {
        UpdateMusicText("Safe");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            Debug.Log("Player entered dangerous area. Switching to danger music.");
            SwitchToDangerMusic();
            UpdateMusicText("Danger");
        }
        else if (other.CompareTag("Tavern"))
        {
            Debug.Log("Player entered tavern. Playing tavern music.");
            EnterTavern();
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
        else if (other.CompareTag("Tavern"))
        {
            Debug.Log("Player exited tavern. Stopping tavern music.");
            ExitTavern();
        }
    }

    private void EnterTavern()
    {
        StopSafeMusic();
        StopDangerMusic();
        tavernMusic.Play();
        isInTavern = true;
        UpdateMusicText("Tavern");
    }

    private void ExitTavern()
    {
        tavernMusic.Stop();
        isInTavern = false;
        UpdateMusicText("Safe"); // Update the text back to "Safe"
        SwitchToSafeMusic();
    }

    private void SwitchToSafeMusic()
    {
        if (!isInTavern && !safeMusic.isPlaying)
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
        if (!isInTavern && !dangerMusic.isPlaying)
        {
            if (isCrossfading)
            {
                StopAllCoroutines();
            }
            StartCoroutine(Crossfade(dangerMusic, safeMusic, crossfadeDuration));
        }
    }

    private void StopSafeMusic()
    {
        if (safeMusic.isPlaying)
        {
            safeMusic.Stop();
        }
    }

    private void StopDangerMusic()
    {
        if (dangerMusic.isPlaying)
        {
            dangerMusic.Stop();
        }
    }

    private IEnumerator Crossfade(AudioSource fadeIn, AudioSource fadeOut, float duration)
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
