using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class CarTractionControl:MonoBehaviour {

	private WheelCollider[] WheelColliders;
	private int wheelsOnGrass = 0; 

	// Use this for initialization
	void Start () {
		WheelColliders = GetComponentsInChildren<WheelCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		wheelsOnGrass = 0;
		for (int i = 0; i < WheelColliders.Length; i++) {
			WheelHit hit = new WheelHit();
			if(WheelColliders[i].GetGroundHit(out hit) && hit.collider.name == "RoadGrass") {
				wheelsOnGrass++;
			}
		}
		GetComponent<UnityStandardAssets.Vehicles.Car.CarController>().m_SteerHelper = 1 - (wheelsOnGrass * 0.08f);
	}
}
