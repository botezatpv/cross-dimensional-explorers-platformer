using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {
    public float speed = 3f;
    float directionX = 1;
    float directionY = 1;
    public Vector2[] coordinates;
    Vector2 target;
    public bool moveInOneEnd = false;
    public bool moveStraightToStart = false;
    int nextPointIndex = 0;
    Transform platformPosition;
    Transform parent;
    public float movement;
    // Use this for initialization
    void Awake () {
        platformPosition = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        float platformX = platformPosition.transform.position.x;
        float platformY = platformPosition.transform.position.y;
        if (nextPointIndex < coordinates.Length)
        {
            target = coordinates[nextPointIndex];
            if (target.x - platformX >= 0) directionX = 1;
            else if (target.x - platformX <= 0) directionX = -1;

            if (target.y - platformY >= 0) directionY = 1;
            else if (target.y - platformY <= 0) directionY = -1;

            /**
             * Computing sin and cos between two points
             * Moving platform toward target point
             * Movement is linear with constant speed
             */
            var distanceAB = Vector2.Distance(target, platformPosition.transform.position);
            var sinPhi = Vector2.Distance(platformPosition.transform.position, new Vector2(target.x, platformY)) / distanceAB;
            var cosPhi = Vector2.Distance(target, new Vector2(target.x, platformY)) / distanceAB;

            /**
             * If platform reached target point go to next one
             */
            if (Mathf.Abs(Vector2.Distance(target, platformPosition.transform.position)) <= 0.2) nextPointIndex += 1;

            platformPosition.Translate(new Vector3(speed * directionX * sinPhi * Time.deltaTime, speed * directionY * cosPhi * Time.deltaTime, 0));
        } else if (!moveInOneEnd && !moveStraightToStart)
        {
            /**
             * Going back to start point and visaverse
             */
            nextPointIndex = 0;
            System.Array.Reverse(coordinates);
        } else if (moveStraightToStart && !moveInOneEnd) nextPointIndex = 0;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        parent = collision.transform.parent;
        collision.transform.parent = platformPosition;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = parent;
    }

}
