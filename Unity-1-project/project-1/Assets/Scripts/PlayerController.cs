using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private int spheresCollected = 0;
    private bool hasWon = false;
    public GameObject gameOverObject; // Reference to the game over UI object
    public UIManager uiManager; // Reference to the UIManager script
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip winAudioClip; // Reference to the win audio clip

    void Start()
    {
        // Ensure that the AudioSource component is attached to the same GameObject as this script
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasWon && other.CompareTag("Finish"))
        {
            // Disable the collected sphere
            other.gameObject.SetActive(false);

            // Increase the count of collected spheres
            spheresCollected++;

            Debug.Log($"Sphere collected! Total Spheres Collected: {spheresCollected}");

            // Check if all spheres are collected
            if (spheresCollected >= 3)
            {
                hasWon = true;
                // Activate the game over UI object
                if (gameOverObject != null)
                {
                    gameOverObject.SetActive(true);
                }
                

                // Freeze the game by setting timeScale to 0
                Time.timeScale = 0f;
                Debug.Log("All Spheres Collected - Game Over!");
                if (audioSource != null && winAudioClip != null)
                {
                    Debug.Log("Playing Win Audio Clip");
                    audioSource.PlayOneShot(winAudioClip);
                }
            }
        }
    }


}