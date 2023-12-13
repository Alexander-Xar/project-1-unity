using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsHandler : MonoBehaviour
{
    public float pushForce = 10f; // Adjust the force applied to the sphere
    public float proximityThreshold = 2f; // Adjust the distance threshold for triggering the action

    void Update()
    {
        // Check if the player pressed the "E" key and is very near the sphere
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerVeryNear())
        {
            // Attempt to get the Rigidbody component
            Rigidbody sphereRigidbody = GetComponent<Rigidbody>();

            // Ensure the Rigidbody component is not null
            if (sphereRigidbody != null)
            {
                // Calculate the push direction based on the player's position
                Vector3 pushDirection = (transform.position - Camera.main.transform.position).normalized;

                // Apply force to push the sphere
                sphereRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
            }
        }
    }

    // Check if the player is very near the sphere based on the proximityThreshold
    bool IsPlayerVeryNear()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        return distance < proximityThreshold;
    }
}
