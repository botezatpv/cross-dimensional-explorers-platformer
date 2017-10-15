using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellGeneral : MonoBehaviour {

    public float spellSpeed;
    public float spellTime;
    public float direction = 1f;
    public float spellDamage = 3f;

    Rigidbody2D spellRigidbody;
    // Update is called once per frame
    private void Start()
    {
        spellRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update () {
        if (spellTime >= 0)
        {
            spellRigidbody.velocity = new Vector2(spellSpeed * direction, 0f);
            spellTime -= Time.deltaTime;
        }
        else Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Monster"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
