using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereHandler : MonoBehaviour
{
    public Transform player;
    public Material material;
    public float playIfProximityOver = 0.8f;
    public float stopIfProximityUnder = 1f;

    private float minDistance = 1.7f;
    private float maxDistance = 10f;

    [SerializeField] private Color colorAt0; 
    [SerializeField] private Color colorAt1; 

    private void Awake()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;
    }

    private void Update()
    {
        UpdateColorBasedOnProximity();
    }

    private void UpdateColorBasedOnProximity()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        float distance01 = (distance - minDistance) / (maxDistance - minDistance);
        float proximity01 = 1 - distance01;

        // Material color lerp
        material.color = Color.Lerp(colorAt0, colorAt1, proximity01);

        // Debug proximity
        Debug.Log($"Proximity is {proximity01}");

       
    }
}