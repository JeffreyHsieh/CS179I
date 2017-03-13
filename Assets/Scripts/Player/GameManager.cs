using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public enum CharacterState{Move, Interact};

public class GameManager : MonoBehaviour {

	public CharacterState player;
    public Button worldButton;
    public string[] worlds;
    private LoadScene loadscene;
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

                loadscene = newWorld.GetComponent<LoadScene>();
                if (loadscene)
                {
                    loadscene.index = worlds[i];
                }
                

                /*
                Image newWorldImage = newWorld.GetComponent<Image>();

                string filePath = @"C:\Users\Narvik\Documents\GitHub\CS179I\Assets\Screenshots";
                byte[] bytes = File.ReadAllBytes(filePath);
                Sprite newWorldSprite = Resources.Load("Screenshots/hello") as Sprite;

                if (newWorldSprite)
                {
                    Debug.Log("Image found");
                }
                else
                {
                    Debug.Log("no image found");
                }

                newWorldImage.sprite = newWorldSprite;
                */
            }
        }
        else
        {
            Debug.Log("You have no worlds");
        }
    }

	void Start () {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
        Application.CaptureScreenshot("Assets/Resources/" + scene.name.ToLower() + ".png");

	}

	void Update () {
	}
}
