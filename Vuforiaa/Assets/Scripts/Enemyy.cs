using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyy : MonoBehaviour {


    public float maxSpeed = 1f;
    public float speed = 1f;

    private Rigidbody rb2d;

    void Start () {
        rb2d = GetComponent<Rigidbody>();
    }
	
	
	void Update () {
        rb2d.AddForce(Vector3.right * speed);
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector3(limitedSpeed, rb2d.velocity.y);

        if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f)
        {
            speed = -speed;
            rb2d.velocity = new Vector3 (speed, rb2d.velocity.y);

        }
    }
}

