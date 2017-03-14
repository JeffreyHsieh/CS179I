using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {
	public GameObject obj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other){
		 //FirstPersonController player = other.GameObject.GetComponent<FirstPersonController>();
		 other.transform.position = obj.transform.position;

	}
}
