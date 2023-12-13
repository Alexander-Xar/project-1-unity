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
        SetGameOverTextActive(false);
    }

    void Update()
    {
        // Check if the game is frozen (timeScale is 0)
        if (IsGameFrozen())
        {
            // Activate the game over text
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

    bool IsGameFrozen()
    {
        return Time.timeScale == 0f;
    }
}