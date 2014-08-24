using UnityEngine;
using System.Collections;

public class EventHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
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
