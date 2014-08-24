using UnityEngine;
using System.Collections;

public class CustomEvents : MonoBehaviour {

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
	
	}
}
