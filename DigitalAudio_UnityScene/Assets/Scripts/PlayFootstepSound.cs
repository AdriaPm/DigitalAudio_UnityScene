using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayFootstepSound : MonoBehaviour
{
    public AudioClip[] footstepsOnGround;
    public AudioClip[] footstepsOnWood;
    public AudioClip[] footstepsOnFloor;
    public AudioClip[] footstepsOnRock;
    public AudioClip[] footstepsOnMetal;
    
    public string material;

    void WhenPlayingFootstepSound(){
        AudioSource myAudioSource = GetComponent<AudioSource>();
        myAudioSource.volume = Random.Range(0.8f, 1.0f);       
        myAudioSource.pitch = Random.Range(0.8f, 1.0f);       
     
        switch(material)
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

    private void OnCollisionEnter(Collision collison)
    {
        switch(collison.gameObject.tag)
        {
            case "Ground":
            case "Wood":
            case "Floor":
            case "Rock":
            case "Metal":
            material = collison.gameObject.tag;
            break;

            default:
            break;
        }

    }

}
    
