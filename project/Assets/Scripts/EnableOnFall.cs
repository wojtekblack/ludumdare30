using UnityEngine;
using System;
using System.Collections;

public class EnableOnFall : MonoBehaviour {

	private Canvas canvas;
	private Animation anim;
	public EventHandler eventHandler;

	// Use this for initialization
	void Start () {
		canvas = gameObject.GetComponent<Canvas> ();
		anim = gameObject.GetComponent<Animation> ();
		canvas.enabled = false;

		eventHandler.GameOver += new EventHandler.GameOverEventHandler (OnFall);
	}

	void OnFall(object sender, EventArgs e) {
		anim.Play ("canvas_fadeIn");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
