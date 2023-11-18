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
    [SerializeField] private AudioSource bossSound;
    private bool soundPlayed = false;

    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float shootCooldown = 2f;
    private float lastShootTime;
    private bool shouldShoot = false; // Add this flag

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector3 initialPosition;
    private Vector3 targetPosition;

    void Start()
    {
        initialPosition = transform.position;
        SetRandomTarget();

        // Get the Animator component
        animator = GetComponent<Animator>();
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        lastShootTime = 0f;
    }

    void Update()
    {
        if (isFollowingPlayer)
        {
            if (!soundPlayed)
            {
                bossSound.Play();
                soundPlayed = true;
            }

            // Shooting logic
            if (shouldShoot && Time.time - lastShootTime >= shootCooldown)
            {
                Shoot();
                lastShootTime = Time.time;
            }

            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            transform.Translate(directionToPlayer * followSpeed * Time.deltaTime);

            // Set Animator parameter for running
            animator.SetBool("IsRunning", true);

            // Flip the sprite based on the direction of movement
            if (directionToPlayer.x < 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, player.position) < followRange)
            {
                isFollowingPlayer = true;
                shouldShoot = true; // Enable shooting when following

                // Set Animator parameter for running
                animator.SetBool("IsRunning", true);
            }
            else
            {
                // Stand still and do not move
                // Set Animator parameter for running to false
                animator.SetBool("IsRunning", false);

                // Flip the sprite based on the direction to the target position
                if (targetPosition.x < transform.position.x)
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;
                }
            }
        }
    }

    void SetRandomTarget()
    {
        targetPosition = initialPosition + new Vector3(Random.Range(-2f, 2f), 0, 0);
    }

    void Shoot()
    {
        // Create a bullet instance at the shoot point's position
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        // Calculate bullet's direction based on the enemy's orientation
        Vector3 bulletDirection = spriteRenderer.flipX ? Vector3.right : Vector3.left;

        // Set the bullet's speed and direction
        bullet.GetComponent<EnemyBullet>().SetDirection(bulletDirection);

        // Set the bullet's damage, effects, etc. if necessary
    }
}
