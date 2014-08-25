using UnityEngine;
using System;
using System.Collections;

public class PlatformController : MonoBehaviour {

	public EventHandler eventHandler;
	public string colorString;
	private Animator anim;
	private Color color;

	// Use this for initialization
	void Start () {
		eventHandler.InitPlatforms += new EventHandler.GameEventHandler (Initialize);

		if (colorString == "red")
			eventHandler.RedPortal += new EventHandler.GameEventHandler (OnFade);
		if (colorString == "green")
			eventHandler.GreenPortal += new EventHandler.GameEventHandler (OnFade);
		if (colorString == "blue")
			eventHandler.BluePortal += new EventHandler.GameEventHandler (OnFade);

		eventHandler.SendMessage ("SetColor", this);
		anim = gameObject.GetComponent<Animator> ();
		SpriteRenderer[] children = gameObject.GetComponentsInChildren<SpriteRenderer> ();
		foreach(SpriteRenderer sr in children)
			sr.color = color;
	}

	void Initialize(object sender, EventHandler.MessageEventArgs e) {
		if (!(e.Message == colorString))
			anim.SetTrigger ("fade");
	}

	void SetColor(Color color) {
		this.color = color;
	}

	void OnFade(object sender, EventHandler.MessageEventArgs e) {
		anim.SetTrigger ("fade");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
