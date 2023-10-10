using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;   // Speed of horizontal movement
    public float jumpForce = 10.0f;  // Force applied for jumping
    private Animator anim;
    private Rigidbody2D Player;

    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
            Player.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        UpdateAnimation();
        
    }
    void UpdateAnimation()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput > 0f) 
        {
            anim.SetBool("running", true);
        }
        else if (horizontalInput < 0f)
        {
            anim.SetBool("running", true);
        }
        else 
        {
            anim.SetBool("running", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("jumping", true);
        }
        else if (horizontalInput > 0f) 
        {
            anim.SetBool("jumping", false);
        }

        
    }
}
