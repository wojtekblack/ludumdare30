using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomEvents : MonoBehaviour {

	public Slider timer;
	public float expirationSpeed = 1.0f;

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
	}
}
