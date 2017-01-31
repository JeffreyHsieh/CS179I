using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	public float speed;
	private Rigidbody body;

	void Start () {
		body = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		float moveX = Input.GetAxis ("Horizontal");
		float moveY = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveX, 0.0f, moveY);
		body.AddForce (movement * speed);
	}
}
