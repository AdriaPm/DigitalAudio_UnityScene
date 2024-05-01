using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class PlayFootstepSound : MonoBehaviour
{
    public AudioClip[] footstepsOnGround;
    public AudioClip[] footstepsOnWood;
    public AudioClip[] footstepsOnFloor;
    public AudioClip[] footstepsOnRock;
    public AudioClip[] footstepsOnMetal;

    private AudioSource myAudioSource;
    private string material;

    public TextMeshProUGUI materialText; // Reference to the TextMeshProUGUI UI element

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    void WhenPlayingFootstepSound()
    {
        myAudioSource.volume = Random.Range(0.8f, 1.0f);
        myAudioSource.pitch = Random.Range(0.8f, 1.0f);

        switch (material)
        {
            case "Ground":
                myAudioSource.PlayOneShot(footstepsOnGround[Random.Range(0, footstepsOnGround.Length)]);
                break;

            case "Wood":
                myAudioSource.PlayOneShot(footstepsOnWood[Random.Range(0, footstepsOnWood.Length)]);
                break;

            case "Floor":
                myAudioSource.PlayOneShot(footstepsOnFloor[Random.Range(0, footstepsOnFloor.Length)]);
                break;

            case "Rock":
                myAudioSource.PlayOneShot(footstepsOnRock[Random.Range(0, footstepsOnRock.Length)]);
                break;

            case "Metal":
                myAudioSource.PlayOneShot(footstepsOnMetal[Random.Range(0, footstepsOnMetal.Length)]);
                break;

            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
            case "Wood":
            case "Floor":
            case "Rock":
            case "Metal":
                material = collision.gameObject.tag;
                WhenPlayingFootstepSound();
                UpdateMaterialText(material);
                break;

            case "Indoor":
                material = collision.gameObject.tag;
                Debug.Log("Player entered indoor area. Applying reverb and echo to footstep sound.");
                AddReverbAndEcho();
                UpdateMaterialText(material);
                break;

            default:
                break;
        }
    }

    private void AddReverbAndEcho()
    {
        // Add reverb and echo effects to the audio source
        myAudioSource.outputAudioMixerGroup.audioMixer.SetFloat("ReverbWet", 1.0f); // Adjust "ReverbWet" parameter to apply reverb
        myAudioSource.outputAudioMixerGroup.audioMixer.SetFloat("EchoWet", 1.0f); // Adjust "EchoWet" parameter to apply echo
    }

    private void UpdateMaterialText(string text)
    {
        // Update the TextMeshProUGUI with the provided text
        if (materialText != null)
        {
            materialText.text = text;
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI UI element is not assigned!");
        }
    }
}
