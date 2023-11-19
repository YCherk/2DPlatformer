using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;  
    public float jumpForce = 10.0f;  
    private Animator anim;
    private Rigidbody2D playerRigidbody;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask jumpableground;
    private enum MoveState { idle, running, jumping, falling }
    private bool canDoubleJump = false;
    private bool hasOrange = false; 
    [SerializeField] private AudioSource JumpSoundEffect;
    [SerializeField] private AudioSource DoubleJumpSoundEffect;
    
    

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent <Animator>();
        sprite = GetComponent <SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Get user input for movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, playerRigidbody.velocity.y);
        playerRigidbody.velocity = movement;

        // Check for jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (Grounded())
            {
                playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                canDoubleJump = true;
                JumpSoundEffect.Play();
            }
            else if (canDoubleJump && hasOrange) // Check for having an orange before double jumping
            {
                playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                canDoubleJump = false;
                DoubleJumpSoundEffect.Play();
                
            }
        }

        UpdateAnimation();
    }

   

    private bool Grounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableground);
    }

    
    public void CollectOrange()
    {
        hasOrange = true;
    }

    void UpdateAnimation()
    {
        MoveState state;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput > 0f)
        {
            state = MoveState.running;
            sprite.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            state = MoveState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MoveState.idle;
        }

        if (playerRigidbody.velocity.y > 0.1f)
        {
            state = MoveState.jumping;
        }
        else if (playerRigidbody.velocity.y < -0.1f)
        {
            state = MoveState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
}
