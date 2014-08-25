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
		eventHandler.Portal += new EventHandler.GameEventHandler (OnPortal);

		eventHandler.SendMessage ("SetColor", this);
		anim = gameObject.GetComponent<Animator> ();
		SpriteRenderer[] children = gameObject.GetComponentsInChildren<SpriteRenderer> ();
		foreach(SpriteRenderer sr in children)
			sr.color = color;
	}

	void OnPortal(object sender, EventHandler.MessageEventArgs e) {
		if (e.Message == colorString)
			anim.SetTrigger ("fadeIn");
		else
			anim.SetTrigger ("fadeOut");
	}

	void Initialize(object sender, EventHandler.MessageEventArgs e) {
		if (!(e.Message == colorString))
			anim.SetTrigger ("fadeOut");
	}

	void SetColor(Color color) {
		this.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
