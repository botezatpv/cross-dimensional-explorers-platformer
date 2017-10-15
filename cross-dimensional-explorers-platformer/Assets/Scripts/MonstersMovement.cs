using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersMovement : MonoBehaviour {

    public Transform Player;
    public float monsterSpeed;
    public float attackDistance;
    public float attackPerSeconds;
    public float minimalDistanceToPlayer;
    public float senseDistance;
    public bool meleeMonster;
    bool facingRight = true;
    int directionIndex = -1;
    float time = 1;
    Rigidbody2D monsterRigidbody;
    Animator anim;

    MovementGeneral movementGeneral;
    // Use this for initialization
    void Start () {
        movementGeneral = GetComponent<MovementGeneral>();
        monsterRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        Flip();
        MoveToPlayer();
    }

    /**
     * Moves monster towards player
     * If monster can attack and monstar is staying on attack distance
     * than monster attack
     */
    void MoveToPlayer()
    {
        if (DistanceBetweenMonsterPlayer(true) <= senseDistance)
        {
            if (DistanceBetweenMonsterPlayer(true) >= minimalDistanceToPlayer)
            {
                monsterRigidbody.velocity = new Vector2(directionIndex * monsterSpeed, monsterRigidbody.velocity.y);
                anim.SetFloat("monsterVelocity", Mathf.Abs(monsterRigidbody.velocity.x));
            }
            else
            {
                monsterRigidbody.velocity = new Vector2(0.00000001f, 0f);
                anim.SetFloat("monsterVelocity", Mathf.Abs(monsterRigidbody.velocity.x));
            }
        } else
        {
            monsterRigidbody.velocity = new Vector2(0.00000001f, 0f);
            anim.SetFloat("monsterVelocity", Mathf.Abs(monsterRigidbody.velocity.x));
        }
    }
    
    /**
     * Turn monster towards player
     */
    void Flip()
    {
        if (DistanceBetweenMonsterPlayer(false) < -1 && facingRight)
        {
            facingRight = movementGeneral.Flip(facingRight, transform);
            directionIndex = 1;
        }
        else if (DistanceBetweenMonsterPlayer(false) > 1 && !facingRight)
        {
            facingRight = movementGeneral.Flip(facingRight, transform);
            directionIndex = -1;
        }
    }
    /**
     * Check distance between monster and player
     * If absolute = true than Vector2.Distance method is used
     * else return distance between x coodrinates
     */
    float DistanceBetweenMonsterPlayer(bool absolute = true)
    {
        if (absolute) return Vector2.Distance(transform.position, Player.transform.position);
        else if (!absolute) return transform.position.x - Player.transform.position.x;
        else return -1;
    }

    /**
     * Decides wether monster can attack or no
     * base on it's attack per second parameter
     */
    bool CanAttak()
    {
        if (attackPerSeconds != 0 && time <= 0) time = 1 / attackPerSeconds;
        else time -= Time.deltaTime;
        if (time <= 0) return true;
        else return false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (CanAttak())
            {
                Player.GetComponent<PlayerStats>().Respawn();
                anim.SetBool("attack", true);
            } else
            {
                anim.SetBool("attack", false);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("attack", false);
    }
}
