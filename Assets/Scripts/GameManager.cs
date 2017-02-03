using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState{Move, Interact};

public class GameManager : MonoBehaviour {

	public CharacterState player;

	void Start () {
		// Set initial state to movement.
		player = CharacterState.Move;
	}

	void Update () {
		switch(player){
		case CharacterState.Move:
			// If the player initiates interaction UI, switch to interact state.
			if(Input.GetButtonDown("Space")){
				player = CharacterState.Interact;
			}
			break;
		case CharacterState.Interact:
			// If the player terminates interaction UI, switch to move state.
			if(Input.GetButtonDown("Space")){
				player = CharacterState.Move;
			}
			break;
		default:
			player = CharacterState.Move;
			break;
		}
	}
}
