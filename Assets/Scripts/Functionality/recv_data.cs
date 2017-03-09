using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;
using SFB;

public class recv_data : MonoBehaviour {

	public string option = "";
	public string ip_address;
	private string URL = "/social_vr/client.php?option_post=";
	
	//public Texture image;
	public string file_path; 
    private string explorer_path;


    // Use this for initialization
	void Start(){
        //onGUI();
		URL = "http://"+ip_address+URL+option;
		file_path = @"C:\Users\domop_000\Pictures\Game\FancyCat.jpg";
		load_from_file(file_path);
	}

	
 	public void load_from_file(string path) {
        byte[] bytes = File.ReadAllBytes(path);
        Texture2D tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        //tex.filterMode = FilterMode.Trilinear;
        tex.LoadImage(bytes);
 
        GetComponent<Renderer>().material.mainTexture = tex;
    }

    public void load_from_explorer(){
        
    }

    IEnumerator update_photo() {
    
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        WWW www = new WWW(URL);
        while (www.isDone == false) {
            //if(progressGUI !=null) progressGUI.text = "Progresso do video: " + (int)(100.0f * www.progress) + "%";
            Debug.Log("Image: Loading");
            yield return 0;
        }
        //yield return www;
        www.LoadImageIntoTexture(tex);
        GetComponent<Renderer>().material.mainTexture = tex;
    }

    void Update(){
    	if(Input.GetKeyDown(KeyCode.Space)){
    		StartCoroutine(update_photo());
    	}
        if(Input.GetKeyDown(KeyCode.B)){
            //onGUI();
            //load_from_file(explorer_path);
        }
    }

    //-----------------------------------------Ruyun Functions below
    /*
    void onGUI() {
        var guiScale = new Vector3(Screen.width / 640.0f, Screen.height / 480.0f, 1.0f);
        Matrix4x4.TRS(Vector3.zero, Quaternion.identity, guiScale);

        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        GUILayout.Space(20);
        GUILayout.BeginVertical();

        GUILayout.Space(5);
        if (GUILayout.Button("Open File Filter")) {
            var extensions = new [] {
                new ExtensionFilter("Image Files", "png", "jpg", "jpeg" ),
                new ExtensionFilter("Sound Files", "mp3", "wav" ),
                new ExtensionFilter("Video Files", "mp4", "ogg" ),
                new ExtensionFilter("All Files", "*" ),
            };
            WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true));
        }

        GUILayout.Space(15);

        GUILayout.Space(15);


        GUILayout.EndVertical();
        GUILayout.Space(20);
        GUILayout.Label(explorer_path);
        GUILayout.EndHorizontal();
    }

    private void WriteResult(string[] paths) {
        if (paths.Length == 0) {
            return;
        }

        explorer_path = "";
        foreach (var p in paths) {
            explorer_path += p + "\n";
        }
    }*/
    
	
}



