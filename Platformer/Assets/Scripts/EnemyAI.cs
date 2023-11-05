using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;  // Speed of random left-right movement
    public float followSpeed = 4f;  // Speed when following the player
    public float followRange = 5f;  // Range within which the enemy starts following the player
    public Transform player;  // Reference to the player's transform
    public bool isFollowingPlayer = false;  // Flag to track if the enemy is following the player

    private Vector3 initialPosition;  // Initial position for random movement
    private Vector3 targetPosition;  // Target position for random movement

    void Start()
    {
        // Store the initial position for random movement
        initialPosition = transform.position;

        // Set the initial random target position
        SetRandomTarget();
    }

    void Update()
    {
        if (isFollowingPlayer)
        {
            // Calculate direction to the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // Move towards the player
            transform.Translate(directionToPlayer * followSpeed * Time.deltaTime);
        }
        else
        {
            // Check if the player is within followRange
            if (Vector3.Distance(transform.position, player.position) < followRange)
            {
                isFollowingPlayer = true;
            }
            else
            {
                // Move randomly left and right within a limited range
                transform.Translate((targetPosition - transform.position).normalized * moveSpeed * Time.deltaTime);

                // Check if the enemy has reached the target position
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    // Set a new random target position
                    SetRandomTarget();
                }
            }
        }
    }

    void SetRandomTarget()
    {
        // Generate a random target position within the initial range
        targetPosition = initialPosition + new Vector3(Random.Range(-2f, 2f), 0, 0);
    }
}
