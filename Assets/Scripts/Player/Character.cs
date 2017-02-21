using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	public float speed;
	public float agility;
	public CharacterState player;
	private Rigidbody body;

	void Start() {
		body = GetComponent<Rigidbody>();
	}
	void Update () {
		// Fetch player state.
		player = GameObject.Find ("GameManager").GetComponent<GameManager> ().player;
		switch (player) {

		// Allow movement in move state.
		case CharacterState.Move:
			float movementX = Input.GetAxis ("Horizontal");
			float movementY = Input.GetAxis ("Vertical");

			transform.Rotate (0, movementX * Time.deltaTime * speed, 0);
			transform.Translate (0, 0, movementY * Time.deltaTime * speed);

			// Jump
			if (Input.GetButtonDown("Jump")) {
				Debug.Log("Jump");
				body.AddForce (new Vector3(0, agility, 0), ForceMode.Impulse);
			}
			break;
		case CharacterState.Interact:
			break;
		default:
			break;
		}
	}
}
