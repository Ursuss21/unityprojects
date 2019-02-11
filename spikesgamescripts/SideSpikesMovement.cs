using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideSpikesMovement : MonoBehaviour {
	public static SideSpikesMovement instance;
	private GameObject spikesUpper, spikesLower;
	private bool moving;
	// Use this for initialization
	void Start () {
		instance = this;
		spikesUpper = GameObject.Find("SpikesSideUpper");
		spikesLower = GameObject.Find("SpikesSideLower");
		moving = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(moving){
			spikesUpper.transform.Translate(new Vector3(0,-1f,0)*Time.deltaTime);
			spikesLower.transform.Translate(new Vector3(0,-1f,0)*Time.deltaTime);
			if(spikesUpper.transform.position.y < -7.8f){
				spikesUpper.transform.position = new Vector3(0, 7.8f, 0);
			}
			if(spikesLower.transform.position.y < -7.8f){
				spikesLower.transform.position = new Vector3(0, 7.8f, 0);
			}
		}
	}

	public void StartMovement(){
		moving = true;
	}
}
