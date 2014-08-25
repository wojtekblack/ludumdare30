using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class EventHandler : MonoBehaviour {

	public delegate void GameEventHandler(object sender, EventArgs e);
	public event GameEventHandler GameOver;

	public Slider timer;
	public float expirationSpeed = 1.0f;
	private EventHandler eventHandler;
	private bool isGameOver = false;

	void Start () {
		eventHandler = gameObject.GetComponent<EventHandler> ();
		GameOver += new GameEventHandler (OnGameOver);
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

	void RetryLevel() {
		Application.LoadLevel (Application.loadedLevelName);
	}
	
	void MainMenu() {
		Application.LoadLevel ("MainMenu");
	}

	void OnGameOver(object sender, EventArgs e) {
		timer.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isGameOver) {
			timer.value -= expirationSpeed * Time.deltaTime;
			if (timer.value <= 0.0f)
				eventHandler.OnGameOver (EventArgs.Empty);
		}
	}
}
