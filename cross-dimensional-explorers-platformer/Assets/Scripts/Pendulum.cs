using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {

    public float leftPushRange;
    public float rightPushRange;
    public float velocity;
    private Rigidbody2D pendulumRigidbody;

	// Use this for initialization
	void Start () {
        pendulumRigidbody = GetComponent<Rigidbody2D>();
        pendulumRigidbody.angularVelocity = velocity;
		
	}
	
	// Update is called once per frame
	void Update () {
        Push();
	}

    void Push()
    {
        if (transform.rotation.z > 0 &&
            transform.rotation.z < rightPushRange &&
            pendulumRigidbody.angularVelocity > 0 &&
            pendulumRigidbody.angularVelocity < velocity)
            pendulumRigidbody.angularVelocity = velocity;
        else if (transform.rotation.z < 0 &&
            transform.rotation.z > leftPushRange &&
            pendulumRigidbody.angularVelocity < 0 &&
            pendulumRigidbody.angularVelocity > velocity * -1)
            pendulumRigidbody.angularVelocity = velocity * -1;
        //if (transform.rotation.z > 0 &&
        //    transform.rotation.z < rightPushRange &&
        //    pendulumRigidbody.angularVelocity < velocity)
        //{
        //    pendulumRigidbody.angularVelocity = velocity;
        //} else if (transform.rotation.z < 0 &&
        //    transform.rotation.z > leftPushRange &&
        //    pendulumRigidbody.angularVelocity > velocity) {
        //    pendulumRigidbody.angularVelocity = -velocity;
        //}
    }
}
