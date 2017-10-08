using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public GameObject respawnPoint;
    public LayerMask trap;
    public int playerLives = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= -30)
        {
            Respawn();
        }
	}

    public void Respawn()
    {
        if (playerLives <= 0)
        {
            transform.position = respawnPoint.transform.position;
        } else
        {
            playerLives -= 1;
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
