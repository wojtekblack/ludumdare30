using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class CustomEvents : MonoBehaviour {

	public Slider timer;
	public float expirationSpeed = 1.0f;
	private EventHandler eventHandler;

	// Use this for initialization
	void Start () {

	}

	void RetryLevel() {
		Application.LoadLevel (Application.loadedLevelName);
	}

	void MainMenu() {
		Application.LoadLevel ("MainMenu");
	}
	
	// Update is called once per frame
	void Update () {
		timer.value -= expirationSpeed * Time.deltaTime;
		if (timer.value <= 0.0f)
			eventHandler.OnGameOver (EventArgs.Empty);
	}
}
