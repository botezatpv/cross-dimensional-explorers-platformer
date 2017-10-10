using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public GameObject respawnPoint;
    public LayerMask trap;
    public int playerLives = 3;
    public float immortalTime;
    public bool canDie;
    public float deathForce = 500f;
    public float deathJumpForce = 100f;
    PlayerMovement playerMovement;
    Rigidbody2D playerRigidBody;
    float deathTimer = -1f;
    int forceDirection = 1;
    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update () {
        if (transform.position.y <= -30)
        {
            Respawn();
        }
        if (deathTimer <= 0)
        {
            canDie = true;
        } else if (deathTimer > 0)
        {
            deathTimer -= Time.deltaTime;
        }
        if(deathTimer <= immortalTime && deathTimer >= immortalTime - 0.3)
        {
            if (playerMovement.facingRight)
                forceDirection = -1;
            else
                forceDirection = 1;
            playerRigidBody.velocity = new Vector2(0, 0);
            playerRigidBody.AddForce(new Vector2(deathForce * forceDirection, 40));
            playerMovement.canMove = false;
        } else
        {
            playerMovement.canMove = true;
        }
	}

    public void Respawn()
    {
        if (canDie)
        {
            if (playerLives <= 0)
            {
                transform.position = respawnPoint.transform.position;
            }
            else
            {
                deathTimer = immortalTime;
                //transform.position = new Vector2(transform.position.x - 1, transform.position.y + 1);
                playerLives -= 1;
                canDie = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == trap)
        {
            Respawn();
        }
    }

}
