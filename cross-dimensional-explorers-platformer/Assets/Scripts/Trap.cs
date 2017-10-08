using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public PlayerStats player;
    bool collided = false;
	// Use this for initialization
	void Start () {
        player = GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collided)
        {
            player.Respawn();
            collided = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        collided = false;
    }
}
