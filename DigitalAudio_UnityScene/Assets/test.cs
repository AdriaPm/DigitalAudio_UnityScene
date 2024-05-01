using UnityEngine;
using TMPro;

public class IndoorText : MonoBehaviour
{
    public TextMeshProUGUI tmpText;

    void Start()
    {
        SetIndoorText();
    }

    private void SetIndoorText()
    {
        if (tmpText != null)
        {
            tmpText.text = "Indoor";
        }
    }
}
