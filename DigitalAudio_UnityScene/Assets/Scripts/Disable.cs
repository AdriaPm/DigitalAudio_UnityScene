using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisableArrowKeyNavigation : MonoBehaviour
{
    void Start()
    {
        // Get all selectable UI elements in the scene
        Selectable[] selectables = FindObjectsOfType<Selectable>();

        // Disable arrow key navigation for each selectable UI element
        foreach (Selectable selectable in selectables)
        {
            Navigation navigation = selectable.navigation;
            navigation.mode = Navigation.Mode.None;
            selectable.navigation = navigation;
        }
    }
}
