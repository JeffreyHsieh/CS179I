// Example of open/save usage with UniFileBrowser
// This script is free to use in any manner

using UnityEngine;
using System.Collections;

public class UniFileBrowserExample : MonoBehaviour {
	
	public string message;
	float alpha = 1.0f;
	char pathChar = '/';
	public bool ShowThisGUI = false;
    public GameObject picture;
    public string object_name;
    private string path;
    
	void Start () {
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) {
			pathChar = '\\';
		}

        picture = GameObject.Find(object_name);

	}

	/*void Update(){
         
        ShowThisGUI = true; //using this for call OnGUI, if you want to call it, just set 'true', otherwise set 'false'
	}*/
	
	void OnGUI () {
		if (ShowThisGUI) {
		
		if (GUI.Button (new Rect(100, 250, 95, 35), "Open")) {
			if (UniFileBrowser.use.allowMultiSelect) {
				UniFileBrowser.use.OpenFileWindow (OpenFiles);
			}
			else {
				UniFileBrowser.use.OpenFileWindow (OpenFile);
			}
		}
		if (GUI.Button (new Rect(100, 200, 95, 35), "Video")) {
			video_player video_script = GameObject.Find("Screen").GetComponent<video_player>();
			video_script.hello("10.25.0.175/php_stuff/client.php?option=video");
			Debug.Log("Called");
		}
		if (GUI.Button (new Rect(100, 300, 95, 35), "Photo")) {
			recv_data photo_script = gameObject.GetComponent<recv_data>();
			photo_script.start_photo();

			Debug.Log("Called");
		}
		var col = GUI.color;
		col.a = alpha;
		GUI.color = col;
		GUI.Label (new Rect(100, 275, 500, 1000), message);
		col.a = 1.0f;
		GUI.color = col;
	}
	}
	
	void OpenFile (string pathToFile) {
        
		var fileIndex = pathToFile.LastIndexOf (pathChar);
		message = /*"You selected file: " + */pathToFile;//pathToFolder+ pathToFile.Substring (fileIndex+1, pathToFile.Length-fileIndex-1);
        picture.GetComponent<recv_data>().file_path = message;

 
            Debug.Log("Not null!");
            Debug.Log(message);
            recv_data pic_script = gameObject.GetComponent<recv_data>();
            video_player video_script = GameObject.Find("Screen").GetComponent<video_player>();
            Debug.Log("message = "+message);
            Debug.Log("message index of dot = "+message.IndexOf('.'));
            Debug.Log("message length = "+message.Length);
            string ext = message.Substring(message.IndexOf('.'), message.Length - message.IndexOf('.') );
                        Debug.Log("message ext = " + ext);

            switch(ext){
            	case ".png":
            	case ".jpg":
            	case ".jpeg":
            		pic_script.load_from_file(message);
            		break;
            	case ".ogv":
            	case ".ogg":
            		video_script.url = message;
            		video_script.File_load_video();
            		break;
            		
            }
            
            ShowThisGUI = false;
       
		Fade();
	}
	
	void OpenFiles (string[] pathsToFiles) {
		//message = "You selected these files:\n";
		for (var i = 0; i < pathsToFiles.Length; i++) {
			var fileIndex = pathsToFiles[i].LastIndexOf (pathChar);
			message += pathsToFiles[i].Substring (fileIndex+1, pathsToFiles[i].Length-fileIndex-1) + "\n";
		}
		Fade();
	}
	
	void SaveFile (string pathToFile) {
		var fileIndex = pathToFile.LastIndexOf (pathChar);
		message = /*"You're saving file: " + */pathToFile.Substring (fileIndex+1, pathToFile.Length-fileIndex-1);
		Fade();
	}
	
	void OpenFolder (string pathToFolder) {
		path = pathToFolder;
		message = "You selected folder: " + pathToFolder;
		Fade();
	}
	
	void Fade () {
		StopCoroutine ("FadeAlpha");	// Interrupt FadeAlpha if it's already running, so only one instance at a time can run
		StartCoroutine ("FadeAlpha");
	}
	
	IEnumerator FadeAlpha () {
		alpha = 1.0f;
		yield return new WaitForSeconds (5.0f);
		for (alpha = 1.0f; alpha > 0.0f; alpha -= Time.deltaTime/4) {
			 yield return null;
		}
		message = "";
	}
}