using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {

	public EventHandler eventHandler;
	public string colorString;
	private Animator anim;
	private Color color;

	// Use this for initialization
	void Start () {
		eventHandler.SendMessage ("SetColor", this);
		anim = gameObject.GetComponent<Animator> ();
		SpriteRenderer[] children = gameObject.GetComponentsInChildren<SpriteRenderer> ();
		foreach(SpriteRenderer sr in children)
			sr.color = color;
	}

	void SetColor(Color color) {
		this.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
