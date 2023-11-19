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
    private bool shouldShoot = false; 

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector3 initialPosition;
    private Vector3 targetPosition;

    void Start()
    {
        initialPosition = transform.position;
        SetRandomTarget();

        
        animator = GetComponent<Animator>();
        
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

           
            if (shouldShoot && Time.time - lastShootTime >= shootCooldown)
            {
                Shoot();
                lastShootTime = Time.time;
            }

            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            transform.Translate(directionToPlayer * followSpeed * Time.deltaTime);

           
            animator.SetBool("IsRunning", true);


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

               
                animator.SetBool("IsRunning", true);
            }
            else
            {
                
                animator.SetBool("IsRunning", false);

                
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
       
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        
        Vector3 bulletDirection = spriteRenderer.flipX ? Vector3.right : Vector3.left;

        bullet.GetComponent<EnemyBullet>().SetDirection(bulletDirection);

       
    }
}
