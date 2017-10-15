using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public PlayerStats player;
    bool collided = false;
	void Start () {
        player = GetComponent<PlayerStats>();

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("TrapObject"))
        {
            if (!collided)
            {
                player.Respawn();
                collided = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collided = false;
    }
}
