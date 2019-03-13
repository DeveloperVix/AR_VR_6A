using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 10f;
	public float speed = 20f;
    public bool grounded;
    public float jumpPower = 6.5f;

	private Rigidbody2D rb2d;
    private Animator anim;
    private bool jump;

    private void Start () {	
		rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update () {

        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            jump = true;
        }

    }

    private void FixedUpdate(){

		float h = Input.GetAxis("Horizontal");

		rb2d.AddForce (Vector2.right * speed * h);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
			rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);


        if (h > 0.1f) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (h < -0.1f) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }


        if (jump) {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
    }
}
