using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class StatsManager : MonoBehaviour {

	Text speedText;

	// Use this for initialization
	void Start () {
		speedText = GameObject.Find("CurrentSpeedText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		speedText.text = "Speed: " + GameObject.Find("Car").GetComponent<CarController>().CurrentSpeedKPH + " kph";
	}
}
