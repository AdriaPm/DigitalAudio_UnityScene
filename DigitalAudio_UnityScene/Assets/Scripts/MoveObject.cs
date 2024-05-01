using UnityEngine;
using UnityEngine.UI;

public class MoveObjectToDestination : MonoBehaviour
{
    public Transform[] destinations; // Array of destination Transforms
    public GameObject objectToMove; // GameObject to move
    private int currentIndex = 0; // Index of the current destination

    void Start()
    {
        // Ensure there's at least one destination
        if (destinations.Length == 0)
        {
            Debug.LogError("No destinations assigned!");
            return;
        }

        // Ensure the object to move is assigned
        if (objectToMove == null)
        {
            Debug.LogError("No object to move assigned!");
            return;
        }

        // Set the initial position to the first destination
        objectToMove.transform.position = destinations[currentIndex].position;
    }

    public void MoveToNextDestination()
    {
        // Increment the index and wrap around if necessary
        currentIndex = (currentIndex + 1) % destinations.Length;

        // Move the object to the new destination
        objectToMove.transform.position = destinations[currentIndex].position;
    }

    public void MoveToPreviousDestination()
    {
        // Decrement the index and wrap around if necessary
        currentIndex = (currentIndex - 1 + destinations.Length) % destinations.Length;

        // Move the object to the new destination
        objectToMove.transform.position = destinations[currentIndex].position;
    }

    public void MoveToDestination(int index)
    {
        // Ensure the index is within the bounds of the destinations array
        if (index >= 0 && index < destinations.Length)
        {
            currentIndex = index;
            objectToMove.transform.position = destinations[currentIndex].position;
        }
        else
        {
            Debug.LogError("Invalid destination index!");
        }
    }
}
