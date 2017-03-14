using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;

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
		if(file_path == null){
            load_from_file(file_path);
        }
        
	}

	
 	public void load_from_file(string path) {
        byte[] bytes = File.ReadAllBytes(path);
        Texture2D tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        //tex.filterMode = FilterMode.Trilinear;
        tex.LoadImage(bytes);
 
        GetComponent<Renderer>().material.mainTexture = tex;
    }

    public void load_from_explorer(){
        UniFileBrowserExample script =gameObject.GetComponent<UniFileBrowserExample>();
        script.ShowThisGUI = true;
        Debug.Log("mesage = '"+script.message+"'");

 
    }

    public void start_photo(){
        StartCoroutine(update_photo());
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
        /*
    	if(Input.GetKeyDown(KeyCode.Space)){
    		StartCoroutine(update_photo());
    	}
        */
        if(Input.GetKeyDown(KeyCode.B)){
            //onGUI();
            //load_from_file(file_path);
            load_from_explorer();
        }
    }
	
}



