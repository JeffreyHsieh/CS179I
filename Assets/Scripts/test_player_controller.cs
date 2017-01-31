using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;   //for networking functions

public class test_player_controller : NetworkBehaviour {    //NetworkBehaviour for controlling local player functions

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //basically if you are not the local player then don't use this function to prevent controlling both characters
        if(!isLocalPlayer)
        {
            return;
        }

        //this grabs arrow key inputs and moves by frame which is why we multiply by delta time and by the speed of how fast we want them to turn.
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
	}
}
