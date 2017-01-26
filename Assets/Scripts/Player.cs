using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float maxSpeed = 7f;
	public float jumpForce = 10f;
	public LayerMask groundLayer;

	private Rigidbody2D body;
	private bool isFacingRight;
	private bool isGrounded;
	private float groundedRadius = .1f;

	Transform groundCheck;

	private void Awake() {
		body = GetComponent<Rigidbody2D> ();
		groundCheck = transform.Find ("GroundCheck");
		isFacingRight = true;
	}

	void FixedUpdate () {
		isGrounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll (groundCheck.position, groundedRadius, groundLayer);
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders [i].gameObject != gameObject) {
				isGrounded = true;
			}
		}
	}

	public void Move (float direction)
	{
		body.velocity = new Vector2 (direction * maxSpeed, body.velocity.y);

		if (direction < 0 && isFacingRight) {
			Flip ();
		} else if (direction > 0 && !isFacingRight) {
			Flip ();
		}
	}

	public void Jump ()
	{
		if (isGrounded) {
			isGrounded = false;
			body.AddForce (new Vector2 (0f, jumpForce));
		}
	}

	public void EndJump ()
	{
		body.AddForce (new Vector2 (0f, jumpForce * -1 * 0.6f));
	}

	private void Flip() {
		isFacingRight = !isFacingRight;

		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
