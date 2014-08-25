using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour {

	public EventHandler eventHandler;
	public string colorString;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		eventHandler.SendMessage ("SetColorPortal", this);
	}

	void OnCollision() {
		eventHandler.OnPortal (new EventHandler.MessageEventArgs (colorString));
		anim.SetTrigger ("fadeOut");	
	}

	void SetColor(Color color) {
		foreach (SpriteRenderer sr in gameObject.GetComponentsInChildren<SpriteRenderer>())
			sr.color = color;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
