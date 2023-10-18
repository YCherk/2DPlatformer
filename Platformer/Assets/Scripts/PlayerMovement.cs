using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;   // Speed of horizontal movement
    public float jumpForce = 10.0f;  // Force applied for jumping
    private Animator anim;
    private Rigidbody2D Player;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask jumpableground;
    private enum MoveState { idle, running, jumping, falling, doubleJump }
    private bool canDoubleJump = true;

    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Get user input for movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, Player.velocity.y);
        Player.velocity = movement;

        // Check for jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (Grounded())
            {
                Player.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                Player.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                canDoubleJump = false;
            }
        }

        UpdateAnimation();
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

        if (Player.velocity.y > 0.1f)
        {
            state = MoveState.jumping;
        }
        else if (Player.velocity.y < -0.1f)
        {
            state = MoveState.falling;
        }

        // Check if the player is in the double jump state
        if (!Grounded() && !canDoubleJump && state != MoveState.falling)
        {
            state = MoveState.doubleJump;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool Grounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableground);
    }
}
