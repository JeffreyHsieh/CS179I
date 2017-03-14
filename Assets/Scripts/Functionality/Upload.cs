using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;
public class Upload : MonoBehaviour
{
    public string ip_address;
    public string file_name;// =  @"C:\Users\domop_000\Videos\so_you.ogg";//@"C:\Users\domop_000\Pictures\Game\FancyCat.jpg";
    private string URL = "http://";
    //public UniFileBrowserExample gameobj;

 void Start(){
        URL = URL+ip_address+"/php_stuff/upload.php";
        
 }

 IEnumerator UploadFile(string localFileName, string uploadURL)
 {
     
     string file = @"file:///"+localFileName;
     Debug.Log("Opening = "+file);
     WWW localFile = new WWW(file);//"file:///" + localFileName);
     yield return localFile;
     if (localFile.error == null)
         Debug.Log("Loaded file");
     else
     {
         Debug.Log("Error while opening: "+localFile.error);
         yield break; // stop the coroutine here
     }
     WWWForm postForm = new WWWForm();
     var fileInfo = new System.IO.FileInfo(localFileName);
     Debug.Log("length = "+fileInfo.Length);
     int current_index = 0;
     int chunk_size = 1000000;
     double total_chunks = Mathf.Ceil((float)(fileInfo.Length/chunk_size)); 
     byte[] buffer = File.ReadAllBytes(localFileName);
     int i =0;
     Debug.Log("total_chunks = "+total_chunks);
     
     while(i < total_chunks)
     {

        Debug.Log("While: i = "+ i);
        postForm.AddField("uid", "1234");
        postForm.AddField("_chunkSize", "100000");
        postForm.AddField("_totalSize", fileInfo.Length.ToString());
        postForm.AddField("_chunkNumber", "1");
        int k = current_index;
        int j = 0;
        byte[] temp =  new byte[chunk_size];
        int end = current_index + chunk_size;
        Debug.Log("current_index + chunk_size = "+end);
        while(k < end){
            temp[j] = buffer[k];
            k++;
        }
        Console.WriteLine(Encoding.Default.GetString(temp));
        postForm.AddBinaryData("file",temp,localFileName,"text/plain");
        //postForm.AddBinaryData("file",localFile.bytes,localFileName,"text/plain");
        Debug.Log("upload URL = "+uploadURL);
        WWW upload = new WWW(uploadURL,postForm);     
         yield return upload;
         if (upload.error == null)
             Debug.Log("Part: "+i+" Upload is done :" + upload.text);
         else{
             Debug.Log("Error uploading: " + upload.error);
             continue;
         }
        current_index+=chunk_size;

        Debug.Log("Current Index "+current_index);
        i++;
     }
     Debug.Log("Finished with all parts!");
        
    
 }
 void Update()
 {
        if(Input.GetKeyDown(KeyCode.R)){
            //StartCoroutine(WWW_load_video(url));
            //gameobj.GetComponent<UniFileBrowserExample>().ShowThisGUI = true;

            //string path = gameobj.GetComponent<UniFileBrowserExample>().message;
            StartCoroutine(UploadFile(file_name, URL));
    }
 }

 /*
 void OnGUI()
 {
     GUILayout.BeginArea(new Rect(0,0,Screen.width,Screen.height));
     m_LocalFileName = GUILayout.TextField(m_LocalFileName);
     m_URL           = GUILayout.TextField(m_URL);
     if (GUILayout.Button("Upload"))
     {
         UploadFile(m_LocalFileName,m_URL);
     }
     GUILayout.EndArea();
 }*/
}