using UnityEngine;
using System;
using System.Collections;

public class EnableOnFall : MonoBehaviour {

	public EventHandler eventHandler;
	private Canvas canvas;
	private Animation anim;

	// Use this for initialization
	void Start () {
		canvas = gameObject.GetComponent<Canvas> ();
		anim = gameObject.GetComponent<Animation> ();
		canvas.enabled = false;

		eventHandler.GameOver += new EventHandler.GameEventHandler (OnFall);
	}

	void OnFall(object sender, EventHandler.MessageEventArgs e) {
		anim.Play ("canvas_fadeIn");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
