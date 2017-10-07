using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float maxSpeed = 10f;
    public bool onGround = false;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float jumpForce = 700f;

    bool facingRight = true;
    Rigidbody2D playerRigidbody;
    Animator anim;
    float groundRadius = 0.2f;
    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        /**
         * Detecting if player is on the ground
         */
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", onGround);
        anim.SetFloat("vSpeed", playerRigidbody.velocity.y);

        /**
         * This code is used for running in x coodrinate
         */
        float move = Input.GetAxis("Horizontal");
        playerRigidbody.velocity = new Vector2(move * maxSpeed, playerRigidbody.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(move));
        if (move > 0 && !facingRight) Flip();
        else if (move < 0 && facingRight) Flip();
	}

    private void Update()
    {
        if (onGround && Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("Ground", false);
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}
