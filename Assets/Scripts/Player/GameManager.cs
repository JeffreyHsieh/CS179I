using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum CharacterState{Move, Interact};

public class GameManager : MonoBehaviour {

	public CharacterState player;
    public Button worldButton;
    public string[] worlds;
    private GameObject loadWorldPanel;


    public void displayWorlds()
    {
        // Find Load world panel.
        loadWorldPanel = GameObject.Find("Canvas/LoadWorldPanel");

        if (worlds.Length > 0)
        {
            float y = 0.0f;
            for(int i = 0; i < worlds.Length; i++)
            {
                Button newWorld = Instantiate(worldButton);
                newWorld.transform.position = new Vector3(0, y, 0);
                newWorld.transform.SetParent(loadWorldPanel.transform, false);
                y = y + newWorld.GetComponent<RectTransform>().rect.height + 10;
            }
        }
        else
        {
            Debug.Log("You have no worlds");
        }
    }

	void Start () {
		// Set initial state to movement.
		player = CharacterState.Move;
	}

	void Update () {
        /*
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
        */
	}
}
