using UnityEngine;
using UnityEngine.UI;

public class ToggleAudioOnProximity : MonoBehaviour
{
    public float activationDistance = 3f; // Distance to activate the audio source
    public Button enableButton; // Reference to the UI button to enable audio
    public Button disableButton; // Reference to the UI button to disable audio

    private GameObject player;
    private AudioSource audioSource;
    private bool audioEnabled = false;
    private bool enableButtonPressed = false;

    void Start()
    {
        // Assuming the player is tagged as "Player"
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();

        // Start with volume at 0
        audioSource.volume = 0f;
        audioSource.loop = true;

        // Hide both buttons initially
        enableButton.gameObject.SetActive(false);
        disableButton.gameObject.SetActive(false);
    }

    void Update()
    {
        // Check if the player is within activation distance
        if (Vector3.Distance(transform.position, player.transform.position) <= activationDistance)
        {
            // Show the enable button only if it hasn't been pressed yet
            if (!enableButtonPressed)
                enableButton.gameObject.SetActive(true);
        }
        else
        {
            // Hide both buttons if the player is not in proximity
            enableButton.gameObject.SetActive(false);
            disableButton.gameObject.SetActive(false);
        }
    }

    public void EnableAudio()
    {
        audioEnabled = true;
        audioSource.volume = 1f;
        audioSource.Play();
        enableButton.gameObject.SetActive(false);
        disableButton.gameObject.SetActive(true);
        enableButtonPressed = true;
    }

    public void DisableAudio()
    {
        audioEnabled = false;
        audioSource.volume = 0f;
        enableButton.gameObject.SetActive(true);
        disableButton.gameObject.SetActive(false);
        enableButtonPressed = false;
    }
}
