using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(AudioSource))]

public class video_player : MonoBehaviour {
    public MovieTexture video;
    private AudioSource audio;

    
	// Use this for initialization
	void Start () {
        //GetComponent<Renderer>().material= video as MovieTexture;
        video = ((MovieTexture)GetComponent<Renderer>().material.mainTexture);//.Play();
        audio = GetComponent<AudioSource>();
        audio.clip = video.audioClip;
        audio.Play();
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
    }
}
