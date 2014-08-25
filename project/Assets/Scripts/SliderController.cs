using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class SliderController : MonoBehaviour {

	public EventHandler eventHandler;
	public float expirationSpeed = 0.02f;

	private Slider slider;
	private bool isGameOver = false;

	// Use this for initialization
	void Start () {
		slider = gameObject.GetComponent<Slider> ();
		eventHandler.GameOver += new EventHandler.GameEventHandler (OnGameOver);
	}

	void OnGameOver(object sender, EventHandler.MessageEventArgs e) {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isGameOver) {
			slider.value -= expirationSpeed * Time.deltaTime;
			if (slider.value <= 0.0f)
				eventHandler.OnGameOver (new EventHandler.MessageEventArgs(""));
		}
	}
}
