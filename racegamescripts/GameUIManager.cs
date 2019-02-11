using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

	PauseMenuManager pauseMenuManager;

	// Use this for initialization
	void Start () {
		pauseMenuManager = GameObject.Find("PauseMenuCanvas").GetComponent<PauseMenuManager>();
		Button pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
		pauseButton.onClick.AddListener(PauseGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PauseGame () {
		pauseMenuManager.ShowPauseMenu();
		GameStateManager.instance.PauseGame();
	}
}
