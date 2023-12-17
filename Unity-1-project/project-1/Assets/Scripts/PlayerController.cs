using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private int spheresCollected = 0;
    private bool hasWon = false;
    public GameObject gameOverObject;
    public UIManager uiManager;
    public AudioSource audioSource;
    public AudioClip winAudioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasWon && other.CompareTag("Finish"))
        {
            HandleSphereCollection(other.gameObject);
        }
    }

    private void HandleSphereCollection(GameObject collectedSphere)
    {
        collectedSphere.SetActive(false);
        spheresCollected++;
        Debug.Log($"Sphere collected! Total Spheres Collected: {spheresCollected}");

        if (spheresCollected >= 3)
        {
            hasWon = true;
            ActivateGameOverUI();
            Time.timeScale = 0f;

            if (audioSource != null && winAudioClip != null)
            {
                audioSource.PlayOneShot(winAudioClip);
            }
        }
    }

    private void ActivateGameOverUI()
    {
        if (gameOverObject != null)
        {
            gameOverObject.SetActive(true);
            uiManager.SetGameOver(true); 
        }
    }
}