using UnityEngine;
using UnityEngine.UI;

public class HelperToggle : MonoBehaviour
{
    public GameObject[] objectsToToggle; // Array of GameObjects to toggle visibility
    public Toggle toggle; // Reference to the UI Toggle component

    void Start()
    {
        // Check if the Toggle component is assigned
        if (toggle != null)
        {
            // Assign the OnValueChanged listener to respond to toggle state changes
            toggle.onValueChanged.AddListener(ToggleObjectsVisibility);
        }
        else
        {
            Debug.LogError("Toggle component not assigned to the script.");
        }
    }

    public void ToggleObjectsVisibility(bool isVisible)
    {
        // Toggle visibility of each GameObject in the array based on the toggle state
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj != null)
            {
                obj.SetActive(isVisible);
            }
            else
            {
                Debug.LogWarning("One or more GameObjects in objectsToToggle array is null.");
            }
        }
    }
}
