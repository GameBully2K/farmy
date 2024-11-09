using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalsMovements : MonoBehaviour
{

    // Customization: Movement speed of the animal (slower walk)
    public float moveSpeed = 0.5f;         // Slow movement for a natural pace
    public float wanderInterval = 4f;      // Change direction every 4 seconds
    public float wanderRadius = 10f;       // Animal can wander within a 10 unit radius
    public float rotationSpeed = 3f;       // Moderate rotation speed to smoothly face new direction

    private Vector3 targetPosition;        // The target position the animal is moving towards
    private float timer;                   // Timer to track when to change direction

    void Start()
    {
        // Initialize the first random target position
        SetNewTargetPosition();
    }

    void Update()
    {
        // Move the animal smoothly towards the target position
        MoveTowardsTarget();

        // Increment timer with elapsed time
        timer += Time.deltaTime;

        // If the timer exceeds the interval, change the direction
        if (timer >= wanderInterval)
        {
            SetNewTargetPosition();  // Choose a new random target position
            timer = 0f;              // Reset the timer for the next direction change
        }
    }

    void MoveTowardsTarget()
    {
        // Only move and rotate if there's a valid target position
        if (targetPosition != null)
        {
            // Smooth movement towards the target position using Lerp
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Calculate direction to the target (without Y-axis, so we stay on the ground)
            Vector3 direction = targetPosition - transform.position;
            direction.y = 0f;  // Ensure movement stays on the X-Z plane

            // If the animal is not yet facing the correct direction
            if (direction.sqrMagnitude > 0.1f) // Only rotate if there's a significant distance
            {
                // Smoothly rotate towards the direction it is moving
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }

    void SetNewTargetPosition()
    {
        // Choose a random position within a radius of the current position
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection.y = 0f;  // Keep the movement on the X-Z plane

        // Set the target position to a new random position within the wandering area
        targetPosition = transform.position + randomDirection;
    }
}