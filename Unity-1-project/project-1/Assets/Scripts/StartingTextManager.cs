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
        
        if (startingText != null)
        {
            startingText.gameObject.SetActive(true);

            
            startTime = Time.time;

           
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
