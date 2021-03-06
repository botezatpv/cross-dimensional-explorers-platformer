﻿using System.Collections;
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
    Animator anim;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    void Update () {
        CheckIfDead();
	}

    void CheckIfDead()
    {

        /**
         * Respawn if fall beyond map
         */
        if (transform.position.y <= -30)
        {
            Respawn();
        }

        /**
         * Check if player can die.
         * Player can't die if had been hit recently
         */
        if (deathTimer <= 0) canDie = true;
        else deathTimer -= Time.deltaTime;

        /**
         * Perform a movement backwards if had been hit recently
         */
        if (deathTimer <= immortalTime && deathTimer >= immortalTime - 0.3)
        {
            /**
             * Detecting a backward direction
             */
            //if (playerMovement.facingRight) forceDirection = -1;
            //else forceDirection = 1;

            /**
             * Adding force to a player
             * Player can't move while he is forced
             */
            //playerRigidBody.velocity = new Vector2(0, 0);
            //playerRigidBody.AddForce(new Vector2(deathForce * forceDirection, 40));
            playerMovement.canMove = false;
        }
        else
        {
            playerMovement.canMove = true;
        }
    }

    /**
     * This function detects if player should respawn or should remove life
     * If life is beyond zero player should respawn
     */
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
                playerLives -= 1;
                canDie = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Trap"))
        {
            Respawn();
        }
    }

}
