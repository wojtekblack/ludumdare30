using UnityEngine;
using System;
using System.Collections;

public class EventHandler : MonoBehaviour {

	public delegate void GameOverEventHandler(object sender, EventArgs e);
	public event GameOverEventHandler GameOver;

	// Use this for initialization
	void Start () {
	}

	public void OnGameOver(EventArgs e) {
		if (GameOver != null)
			GameOver (this, e);
	}

	void OnNewGameClick() {
		Application.LoadLevel ("MainScene");	
	}

	void OnExitClick() {
		Application.Quit ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
