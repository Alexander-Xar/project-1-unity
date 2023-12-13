using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text gameOverText;
    

    void Start()
    {
        // Initially, hide the "Game Over" text
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("GameOverText is not assigned in the inspector!");
        }
    }

    void Update()
    {
        // Check if the game is frozen (timeScale is 0)
        if (Time.timeScale == 0f)
        {
            // Activate the game over text
            if (gameOverText != null && !gameOverText.gameObject.activeSelf)
            {
                gameOverText.gameObject.SetActive(true);
            }
        }
    }
}