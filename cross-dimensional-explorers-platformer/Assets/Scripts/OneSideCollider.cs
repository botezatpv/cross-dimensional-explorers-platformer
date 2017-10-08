using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSideCollider : MonoBehaviour {

    BoxCollider2D gameObjectCollider;
	// Use this for initialization
	void Start () {
        gameObjectCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Physics2D.IgnoreCollision(collision, gameObjectCollider);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Physics2D.IgnoreCollision(collision, gameObjectCollider);
    }
}
