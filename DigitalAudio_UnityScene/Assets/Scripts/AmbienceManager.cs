using UnityEngine;
using TMPro;

public class AmbienceManager : MonoBehaviour
{
    public AudioSource outdoorAmbience;
    public AudioSource indoorAmbience;
    public TextMeshProUGUI ambienceText; // Reference to the TextMeshProUGUI UI element

    void Start()
    {
        UpdateAmbienceText("Outdoor"); // Start with "Outdoor" text
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Indoor"))
        {
            Debug.Log("Player entered indoor area. Switching to indoor ambience.");
            SwitchToIndoorAmbience();
            UpdateAmbienceText("Indoor");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Indoor"))
        {
            Debug.Log("Player exited indoor area. Switching to outdoor ambience.");
            SwitchToOutdoorAmbience();
            UpdateAmbienceText("Outdoor");
        }
    }

    private void SwitchToIndoorAmbience()
    {
        outdoorAmbience.Stop();
        indoorAmbience.Play();
    }

    private void SwitchToOutdoorAmbience()
    {
        indoorAmbience.Stop();
        outdoorAmbience.Play();
    }

    private void UpdateAmbienceText(string text)
    {
        // Update the TextMeshProUGUI with the provided text
        if (ambienceText != null)
        {
            ambienceText.text = text;
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI UI element is not assigned!");
        }
    }
}
