using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text gameOverText;

    private bool isGameOver = false;

    void Start()
    {
        // Initially, hide the "Game Over" text
        SetGameOverTextActive(false);
    }

    void Update()
    {
        // Check if the game is over
        if (isGameOver)
        {
            // Activate the game over text
            SetGameOverTextActive(true);
        }
    }

    public void SetGameOver(bool gameOver)
    {
        
        isGameOver = gameOver;

        
        if (isGameOver && Time.timeScale != 0f)
        {
           
            SetGameOverTextActive(true);
        }
    }

    void SetGameOverTextActive(bool isActive)
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(isActive);
        }
        else
        {
            Debug.LogError("GameOverText is not assigned in the inspector!");
        }
    }
}