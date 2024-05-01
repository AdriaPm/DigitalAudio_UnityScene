using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicChange : MonoBehaviour
{
    public AudioMixerSnapshot baseSnapshot;
    public AudioMixerSnapshot closeSnapshot;
    public AudioMixerSnapshot nextToSnapshot;

    public float slowTransitionTime = 5.0f;
    public float fastTransitionTime = 3.0f;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "CloseToRadio":
                closeSnapshot.TransitionTo(slowTransitionTime);
                break;

            case "NextToRadio":
                nextToSnapshot.TransitionTo(fastTransitionTime);
                break;

            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "CloseToRadio":
                baseSnapshot.TransitionTo(slowTransitionTime);
                break;

            case "NextToRadio":
                closeSnapshot.TransitionTo(slowTransitionTime);
                break;

            default:
                break;
        }
    }
}
