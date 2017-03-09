using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.GUITexture;

[RequireComponent (typeof(AudioSource))]

public class video_player : MonoBehaviour {
    public MovieTexture video;
    private AudioSource audio;
    
    public string url;
    //public string path = ""
    //public string url = @"file:///C:\Users\domop_000\Videos\Short_funny_video.ogv";

	// Use this for initialization
	void Start () {
        //File_load_video();
        StartCoroutine(WWW_load_video(url));
        //GetComponent<Renderer>().material= video as MovieTexture;
        /*
        video = ((MovieTexture)GetComponent<Renderer>().material.mainTexture);//.Play();
        audio = GetComponent<AudioSource>();
        audio.clip = video.audioClip;
        audio.Play();*/
	}

    void Unity_load_video(){

        GetComponent<MeshRenderer>().material.mainTexture = video;

        audio = GetComponent<AudioSource>();
        audio.clip = video.audioClip;
        audio.Play ();
        video.Play ();
     
    }
	
    void File_load_video(){
        string URL = @"file:///"+url;
        StartCoroutine(WWW_load_video(URL));
    }

    IEnumerator WWW_load_video(string URL){
        //if(targetRender ==null) targetRender = GetComponent<MeshRenderer> ();
       // if(audio ==null) 
        //url = "http://www.unity3d.com/Movie/sample.ogg";
        //url = +url
        
        Debug.Log("URL = "+URL);
        WWW www = new WWW (URL);
        yield return www;
        
        Debug.Log("Video downloaded");
        if(www.movie == null)
            Debug.Log("Movie is null");
        video = www.movie;
        
        
        while (!video.isReadyToPlay) {
            yield return null;
            Debug.Log("Loading");
        }
        if(video.isReadyToPlay)
            Debug.Log("Video is ready");

        GetComponent<MeshRenderer>().material.mainTexture = video;
        audio = GetComponent<AudioSource>();

        if(video.audioClip == null){
            Debug.Log("null");
        }
        //if(video.clip == null)
          //  Debug.Log("Clip is null");
        audio.clip = video.audioClip;
        audio.Play ();
        video.Play ();
        yield return null;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab) && video.isPlaying)
        {
            video.Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && !video.isPlaying)
        {
            video.Play();
        }
        else if (Input.GetKeyDown(KeyCode.BackQuote) && !video.isPlaying)
        {
            video.Stop();
            audio.Play();
            video.Play();
        }

        else if(Input.GetKeyDown(KeyCode.Space)){
            //StartCoroutine(WWW_load_video(url));
            
        }
    }

}
