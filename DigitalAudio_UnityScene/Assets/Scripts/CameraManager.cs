using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    public GameObject objectToDeactivate; // GameObject to deactivate when camera index is not 0

    private int currentIndex = 0;
    private bool isObjectActive = true;

    void Start()
    {
        // Disable all cameras except the first one
        DisableAllCameras();
        cameras[0].gameObject.SetActive(true); // Activate the first camera by default
    }

    public void SwitchToCamera(int index)
    {
        // Ensure the index is within the bounds of the cameras array
        if (index >= 0 && index < cameras.Length)
        {
            // Deactivate the specified object if the index is not 0
            if (index != 0 && objectToDeactivate != null && isObjectActive)
            {
                objectToDeactivate.SetActive(false);
                isObjectActive = false;
            }

            // Disable all cameras
            DisableAllCameras();

            // Enable the camera at the specified index
            cameras[index].gameObject.SetActive(true);

            // Reactivate the specified object if switching back to index 0
            if (index == 0 && objectToDeactivate != null && !isObjectActive)
            {
                objectToDeactivate.SetActive(true);
                isObjectActive = true;
            }

            currentIndex = index;
        }
        else
        {
            Debug.LogError("Invalid camera index!");
        }
    }

    void DisableAllCameras()
    {
        foreach (Camera camera in cameras)
        {
            camera.gameObject.SetActive(false);
        }
    }
}
