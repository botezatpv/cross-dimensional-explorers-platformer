using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float maxSpeed = 10f;
    public bool onGround = false;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float jumpForce = 700f;
    public bool canMove = true;
 
    public bool facingRight = true;
    Rigidbody2D playerRigidbody;
    Animator anim;
    Transform playerTransform;
    float groundRadius = 0.2f;
    bool secondJump = true;

    MovementGeneral movementGeneral;

    void Awake () {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        movementGeneral = GetComponent<MovementGeneral>();

    }

    private void Update()
    {
        Move();
        Jump();
        checkIfOnGround();
    }

    /**
     * Detecting if player is on the ground
     */
    public void checkIfOnGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", onGround);
        anim.SetFloat("vSpeed", playerRigidbody.velocity.y);
    }
    /**
     * This code is used for running in x coodrinate
     */
    public void Move()
    {
        if (canMove)
        {
            float move = Input.GetAxis("Horizontal");
            playerRigidbody.velocity = new Vector2(move * maxSpeed, playerRigidbody.velocity.y);
            anim.SetFloat("Speed", Mathf.Abs(move));
            if (move > 0 && !facingRight) facingRight = movementGeneral.Flip(facingRight, transform);
            else if (move < 0 && facingRight) facingRight = movementGeneral.Flip(facingRight, transform);
        }
    }

    public void Jump()
    {

        if (onGround && Input.GetKeyDown(KeyCode.UpArrow) && canMove)
        {
            anim.SetBool("Ground", false);
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            secondJump = true;
        }
        else if (!onGround && Input.GetKeyDown(KeyCode.UpArrow) && canMove && secondJump)
        {
            playerRigidbody.AddForce(new Vector2(0, jumpForce / 2));
            secondJump = false;
        }
    }
}
