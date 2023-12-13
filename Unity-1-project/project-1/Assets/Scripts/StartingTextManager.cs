using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingTextManager : MonoBehaviour
{
    public Text startingText;
    public float startingTextDuration = 10f;

    private float startTime;

    void Start()
    {
        // Ensure the starting text is initially active
        if (startingText != null)
        {
            startingText.gameObject.SetActive(true);

            // Set the start time
            startTime = Time.time;

            // Deactivate the starting text after startingTextDuration seconds
            Invoke("DeactivateStartingText", startingTextDuration);
        }
        else
        {
            Debug.LogError("StartingText is not assigned in the inspector!");
        }
    }

    void DeactivateStartingText()
    {
        // Deactivate the starting text
        if (startingText != null && startingText.gameObject.activeSelf)
        {
            startingText.gameObject.SetActive(false);
        }
    }
}
