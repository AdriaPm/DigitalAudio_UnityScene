using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera mainCamera; // Reference to the camera to look at

    void Start()
    {
        // If no camera is assigned, use the main camera
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        // Make the sprite face the camera
        if (mainCamera != null)
        {
            transform.LookAt(mainCamera.transform.position);
            transform.Rotate(0, 180, 0); // Adjust rotation if necessary
        }
        else
        {
            Debug.LogWarning("No camera assigned to the billboard!");
        }
    }
}
