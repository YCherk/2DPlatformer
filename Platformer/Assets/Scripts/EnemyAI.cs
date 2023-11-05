using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float followSpeed = 4f;
    public float followRange = 5f;
    public Transform player;
    public bool isFollowingPlayer = false;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector3 initialPosition;
    private Vector3 targetPosition;

    void Start()
    {
        initialPosition = transform.position;
        SetRandomTarget();

        // Get the Animator component
        animator = GetComponent <Animator>();
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent <SpriteRenderer>();
    }

    void Update()
    {
        if (isFollowingPlayer)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            transform.Translate(directionToPlayer * followSpeed * Time.deltaTime);

            // Set Animator parameter for running
            animator.SetBool("IsRunning", true);

            // Flip the sprite if moving left
            if (directionToPlayer.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, player.position) < followRange)
            {
                isFollowingPlayer = true;

                // Set Animator parameter for running
                animator.SetBool("IsRunning", true);
            }
            else
            {
                transform.Translate((targetPosition - transform.position).normalized * moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    SetRandomTarget();
                }

                // Set Animator parameter for running
                animator.SetBool("IsRunning", true);

                // Flip the sprite if moving left
                if (moveSpeed < 0)
                {
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }
            }
        }
    }

    void SetRandomTarget()
    {
        targetPosition = initialPosition + new Vector3(Random.Range(-2f, 2f), 0, 0);
    }
}
