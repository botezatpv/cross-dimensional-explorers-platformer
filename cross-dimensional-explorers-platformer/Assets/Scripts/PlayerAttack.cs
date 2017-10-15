using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public GameObject fireball;
    public float castSpeed;
    PlayerMovement playerMovement;
    float timer;
    int direction;
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); 
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            if (playerMovement.facingRight) direction = 1;
            else direction = -1;
            fireball.transform.position = new Vector2(transform.position.x + 1 * direction, transform.position.y);
            fireball.GetComponent<SpellGeneral>().direction = direction;
            //fireball.GetComponent<SpellGeneral>().direction = 
            if (timer <= 0)
            {
                Instantiate(fireball);
                timer = castSpeed;
            }
        }
        timer -= Time.deltaTime;
    }
}
