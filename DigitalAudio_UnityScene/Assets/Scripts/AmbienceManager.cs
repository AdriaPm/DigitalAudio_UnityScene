using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
    public AudioSource outdoorAmbience;
    public AudioSource indoorAmbience;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Indoor"))
        {
            Debug.Log("Player entered indoor area. Switching to indoor ambience.");
            SwitchToIndoorAmbience();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Indoor"))
        {
            Debug.Log("Player exited indoor area. Switching to outdoor ambience.");
            SwitchToOutdoorAmbience();
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
}
