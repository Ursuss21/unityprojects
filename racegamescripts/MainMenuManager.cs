using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

	Button playButton;

	// Use this for initialization
	void Start () {
		playButton = GameObject.Find("PlayButton").GetComponent<Button>();
		playButton.onClick.AddListener(PlayButtonClick);
	}
	
	void PlayButtonClick () {
		GameObject.Find("LevelLoadManager").GetComponent<LevelLoader>().LoadLevel("scene2");
	}
}
