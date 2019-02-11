using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideSpikesManager : MonoBehaviour {
	public static SideSpikesManager instance;
	private bool animationRight, animationLeft;
	private GameObject spikesUpperLeft, spikesUpperRight, spikesLowerLeft, spikesLowerRight;
	private Transform[] smallSpikesUpperLeft, smallSpikesUpperRight, smallSpikesLowerLeft, smallSpikesLowerRight;
	private int numberOfSpikes;
	// Use this for initialization
	void Start () {
		instance = this;
		spikesUpperLeft = GameObject.Find("SpikesSideUpper/SpikesLeft");
		spikesUpperRight = GameObject.Find("SpikesSideUpper/SpikesRight");
		spikesLowerLeft = GameObject.Find("SpikesSideLower/SpikesLeft");
		spikesLowerRight = GameObject.Find("SpikesSideLower/SpikesRight");
		smallSpikesUpperLeft = new Transform[12];
		smallSpikesUpperRight = new Transform[12];
		smallSpikesLowerLeft = new Transform[12];
		smallSpikesLowerRight = new Transform[12];
		for(int i = 0; i<spikesUpperLeft.transform.childCount;i++){
			smallSpikesUpperLeft[i] = spikesUpperLeft.transform.GetChild(i);
			smallSpikesUpperRight[i] = spikesUpperRight.transform.GetChild(i);
			smallSpikesLowerLeft[i] = spikesLowerLeft.transform.GetChild(i);
			smallSpikesLowerRight[i] = spikesLowerRight.transform.GetChild(i);
		}
		numberOfSpikes = 3;
		SideSpikesManager.instance.RandomizeSpikes(true);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(animationRight && spikesUpperLeft.transform.position.x < 0.54f){
			spikesUpperRight.transform.Translate(new Vector2(0.03f, 0f));
			spikesLowerRight.transform.Translate(new Vector2(0.03f, 0f));
		}
		else
			animationRight = false;
		if(animationLeft && spikesUpperRight.transform.position.x > 0.01f){
			spikesUpperLeft.transform.Translate(new Vector2(-0.03f, 0f));
			spikesLowerLeft.transform.Translate(new Vector2(-0.03f, 0f));
		}
		else
			animationLeft = false;
	}
	public void MoveSpikes(bool right){
		if(right) {
			animationLeft = true;
		}
		else{
			animationRight = true;
		}
	}

	public void ToggleSpikesVisibility (bool on) {
		spikesUpperLeft.SetActive(on);
		spikesUpperRight.SetActive(on);
		spikesLowerLeft.SetActive(on);
		spikesLowerRight.SetActive(on);
	}
	public void AddSpikes(){
		if(ScoreManager.instance.score % (numberOfSpikes*numberOfSpikes) == 0 && numberOfSpikes<9){
			numberOfSpikes++;
		}
	}
	
	List<int> randomNumbers = new List<int>();
	int r;
	public void RandomizeSpikes(bool right){
		randomNumbers.Clear();
		for(int i = 0; i < numberOfSpikes; i++)
		{
			do{
				r = Random.Range(0,12);
			}
			while(randomNumbers.Contains(r));
			randomNumbers.Add(r);
		}
		if(right){
			for(int i = 0; i< spikesUpperRight.transform.childCount;i++){
				smallSpikesUpperRight[i].gameObject.SetActive(true);
				if(!randomNumbers.Contains(i)){
					smallSpikesUpperRight[i].gameObject.SetActive(false);
				}
			}
			for(int i = 0; i< spikesLowerRight.transform.childCount;i++){
				smallSpikesLowerRight[i].gameObject.SetActive(true);
				if(!randomNumbers.Contains(i)){
					smallSpikesLowerRight[i].gameObject.SetActive(false);
				}
			}
		}
		else{
			for(int i = 0; i< spikesUpperLeft.transform.childCount;i++){
				smallSpikesUpperLeft[i].gameObject.SetActive(true);
				if(!randomNumbers.Contains(i)){
					smallSpikesUpperLeft[i].gameObject.SetActive(false);
				}
			}
			for(int i = 0; i< spikesLowerLeft.transform.childCount;i++){
				smallSpikesLowerLeft[i].gameObject.SetActive(true);
				if(!randomNumbers.Contains(i)){
					smallSpikesLowerLeft[i].gameObject.SetActive(false);
				}
			}
		}
	}
}
