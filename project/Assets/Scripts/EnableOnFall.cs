using UnityEngine;
using System.Collections;

public class EnableOnFall : MonoBehaviour {

	private Canvas canvas;
	private Animation anim;

	// Use this for initialization
	void Start () {
		canvas = gameObject.GetComponent<Canvas> ();
		anim = gameObject.GetComponent<Animation> ();
		canvas.enabled = false;
	}

	void OnFall() {
		anim.Play ("canvas_fadeIn");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
