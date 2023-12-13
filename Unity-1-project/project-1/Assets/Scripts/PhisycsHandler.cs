using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsHandler : MonoBehaviour
{
    public float pushForce = 10f;
    public float proximityThreshold = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerVeryNear())
        {
            ApplyPushForce();
        }
    }

    bool IsPlayerVeryNear()
    {
        return Vector3.Distance(transform.position, Camera.main.transform.position) < proximityThreshold;
    }

    void ApplyPushForce()
    {
        Rigidbody sphereRigidbody = GetComponent<Rigidbody>();

        if (sphereRigidbody != null)
        {
            Vector3 pushDirection = (transform.position - Camera.main.transform.position).normalized;
            sphereRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}
