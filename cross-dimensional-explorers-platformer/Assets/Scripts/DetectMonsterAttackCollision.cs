using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMonsterAttackCollision : MonoBehaviour {
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(collision.gameObject.GetComponent<PolygonCollider2D>(), transform.GetComponent<PolygonCollider2D>());
        Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CircleCollider2D>(), transform.GetComponent<PolygonCollider2D>());
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(collision.gameObject.GetComponent<PolygonCollider2D>(), transform.GetComponent<PolygonCollider2D>());
        Physics2D.IgnoreCollision(collision.gameObject.GetComponent<CircleCollider2D>(), transform.GetComponent<PolygonCollider2D>());

    }
}
