using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager> {

    void Awake()
    {

    }
	// Use this for initialization
	void Start () {
        Sprite newWorldSprite = Resources.Load("hello/hello") as Sprite;

        if (newWorldSprite)
        {
        }
        else
        {
           // Debug.Log("no image found");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
