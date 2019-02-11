using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class RoadManager:MonoBehaviour {

	public static RoadManager instance; 
	Vector3 lastRoadPosition = Vector3.zero; 
    Vector3 newRoadPosition, lastRoadPosition2; 

	public float MinCurve = 10f; 
	public float MaxCurve = 30f; 

	public void UpdateRoad() {
		GetComponent < RoadCreator > ().UpdateRoad(); 
		DestroyImmediate(GetComponent < MeshCollider > ()); 
        transform.gameObject.AddComponent < MeshCollider > (); 
	}

	public void AddRoad(Vector3 position) {
		GetComponent < PathCreator > ().AddSegmentUsingScript(new Vector2(position.x, position.z)); 
	}
	
	void AddRoadRandomly() {
		 float x = Random.Range(MinCurve, MaxCurve); 
		 float z; 
		 do {		
		 	z = Random.Range(MinCurve, MaxCurve); 
			newRoadPosition = new Vector3(lastRoadPosition.x + x, 0f, lastRoadPosition.z + z); 
		}while (Vector3.Distance(newRoadPosition, lastRoadPosition) < 200); 
        AddRoad(newRoadPosition); 
		lastRoadPosition = newRoadPosition; 
	}

	void AddRoadManually(Vector3 position) {	
		newRoadPosition = position; 
		AddRoad(newRoadPosition); 
		lastRoadPosition = newRoadPosition; 
	}

	void Start () {
		instance = this; 
		
		AddRoadManually(new Vector3(200, 0, 200)); 
		AddRoadManually(new Vector3(300, 0, 300)); 

		for (int i = 0; i < 20; i++) {
			AddRoadRandomly();
		}

		UpdateRoad(); 
		DecorationsManager.instance.AddRoadDecorations(); 
	}

    void Interval () {
        AddRoadRandomly(); 

		//GameObject.Find("Main Camera").transform.position = new Vector3(newRoadPosition.x, 100f, newRoadPosition.z);
		//GameObject.Find("Cube").transform.position = new Vector3(newRoadPosition.x - 3, 10f, newRoadPosition.z - 3); 
		
    }
}
