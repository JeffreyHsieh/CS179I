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
        StartCoroutine(WWW_load_video());
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
	
    IEnumerator WWW_load_video(){

        //if(targetRender ==null) targetRender = GetComponent<MeshRenderer> ();
       // if(audio ==null) 
        //url = "http://www.unity3d.com/Movie/sample.ogg";
        url = @url;
        Debug.Log("URL = "+url);
        WWW www = new WWW (url);
        yield return www;
        
        Debug.Log("Video downloaded");
        if(www.movie == null)
            Debug.Log("It was a lie");
        video = www.movie;
        
        if(video.isReadyToPlay)
            Debug.Log("Video is ready");
        while (!video.isReadyToPlay) {
            yield return null;
            Debug.Log("Loading");
        }

        GetComponent<MeshRenderer>().material.mainTexture = video;
        audio = GetComponent<AudioSource>();

        if(video.audioClip == null){
            Debug.Log("null");
        }
        
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

        else if(Input.GetKeyDown(KeyCode.Z)){
            StartCoroutine(WWW_load_video());
        }
    }

}
