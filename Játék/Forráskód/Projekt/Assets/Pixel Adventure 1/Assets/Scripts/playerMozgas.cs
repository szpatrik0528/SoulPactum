using System.Security.AccessControl;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMozgas : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;
     private bool isGodModeEnabled = false;
    

    private float dirX = 0f;
    private float moveSpeed = 10f;
    private float jumpForce = 14f;
    private enum MovementState {idle,run,jump,fall}   
    private bool god = false; 

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        jump();      
        UpdateAnimationUpdate();
        GodMode();
    }

        private void UpdateAnimationUpdate()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.run;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.run;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }   

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state);
        
    }  
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    private void jump() 
    {
        if (Input.GetKey("space") || Input.GetKey("up") || Input.GetKey("w"))
        {
            
            if(IsGrounded()) 
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector3(rb.velocity.x, jumpForce);
                
            }
        } 
    }
    private void GodMode()
    {
         if (Input.GetKey(KeyCode.G))
        {
            isGodModeEnabled = !isGodModeEnabled;
           // Debug.Log("God Mode: " + (isGodModeEnabled ? "Enabled" : "Disabled"));
        }
    }
    // OnTriggerEnter2D is called when the Collider2D other enters the trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player character enters the trigger
        if (other.CompareTag("Player"))
        {
            if (isGodModeEnabled)
            {
                // If god mode is enabled, destroy any objects that damage the player
                Destroy(other.gameObject);
            }
        }
    }
}