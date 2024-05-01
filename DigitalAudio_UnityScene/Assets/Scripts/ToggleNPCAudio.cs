using UnityEngine;

public class ToggleAudioOnKey : MonoBehaviour
{
    public float activationDistance = 3f; // Distance to activate the audio source
    public KeyCode enableKey = KeyCode.E; // Key to enable the audio
    public KeyCode disableKey = KeyCode.D; // Key to disable the audio

    private GameObject player;
    private AudioSource audioSource;
    private bool audioEnabled = false;

    void Start()
    {
        // Assuming the player is tagged as "Player"
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();

        // Start with volume at 0
        audioSource.volume = 0f;
        audioSource.loop = true;
    }

    void Update()
    {
        // Check if the player is within activation distance
        if (Vector3.Distance(transform.position, player.transform.position) <= activationDistance)
        {
            // Check if the enable key is pressed
            if (Input.GetKeyDown(enableKey))
            {
                audioEnabled = true;
                audioSource.volume = 1f;
                audioSource.Play();
            }

            // Check if the disable key is pressed
            if (Input.GetKeyDown(disableKey))
            {
                audioEnabled = false;
                audioSource.volume = 0f;
            }
        }
    }
}
