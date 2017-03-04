using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;

public class recv_data : MonoBehaviour {

	public static string option = "";
	public string ip_address;
	private string URL = "/social_vr/client.php?option_post="+option;
	
	//public Texture image;
	public string file_path; 


    // Use this for initialization
	void Start(){
		URL = "http://"+ip_address+URL;
		file_path = @"C:\Users\domop_000\Pictures\Game\FancyCat.jpg";
		load_from_file();
	}

	
 	public void load_from_file() {
        byte[] bytes = File.ReadAllBytes(file_path);
        Texture2D tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        //tex.filterMode = FilterMode.Trilinear;
        tex.LoadImage(bytes);
 
        GetComponent<Renderer>().material.mainTexture = tex;
    }

    IEnumerator update_photo() {
    
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        WWW www = new WWW(URL+option);
        yield return www;
        www.LoadImageIntoTexture(tex);
        GetComponent<Renderer>().material.mainTexture = tex;
    }

    void Update(){
    	if(Input.GetKeyDown(KeyCode.Space)){
    		StartCoroutine(update_photo());
    	}
    }

	
}



