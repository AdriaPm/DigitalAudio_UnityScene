using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayFootstepSound : MonoBehaviour
{
    public AudioClip[] footstepsOnGrass;
    public AudioClip[] footstepsOnWood;
    
    public string material;

    void WhenPlayingFootstepSound(){
        AudioSource myAudioSource = GetComponent<AudioSource>();
        myAudioSource.volume = Random.Range(0.8f, 1.0f);       
        myAudioSource.pitch = Random.Range(0.8f, 1.0f);       
     
        switch(material)
        {
            case "Grass":
            myAudioSource.PlayOneShot(footstepsOnGrass[Random.Range(0, footstepsOnGrass.Length)]);
            break;

            case "Wood":
            myAudioSource.PlayOneShot(footstepsOnWood[Random.Range(0, footstepsOnWood.Length)]);
            break;
            
            default:
            break;
        }


    } 

    private void OnCollisionEnter(Collision collison)
    {
        switch(collison.gameObject.tag)
        {
            case "Grass":
            case "Wood":
            material = collison.gameObject.tag;
            break;

            default:
            break;
        }

    }

}
    
