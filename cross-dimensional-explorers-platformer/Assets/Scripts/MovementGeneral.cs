using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementGeneral : MonoBehaviour {

    public bool Flip(bool facingRight, Transform transform)
    {
        facingRight = !facingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
        return facingRight;
    }
}
