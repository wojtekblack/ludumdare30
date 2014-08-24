using UnityEngine;
using System.Collections;

public class CustomEvents : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void RetryLevel() {
		Application.LoadLevel (Application.loadedLevelName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
