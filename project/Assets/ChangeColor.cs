using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {
	
	public GameObject[] children;
	private SpriteRenderer[] childrensSprites;

	// Use this for initialization
	void Start () {
		childrensSprites = new SpriteRenderer[children.Length];
		int i = 0;
		foreach(GameObject go in children)
			childrensSprites[i++] = go.GetComponent<SpriteRenderer>();
	}

	void Change(Color color) {
		foreach (SpriteRenderer sr in childrensSprites)
			sr.color = color;
		Debug.Log (color);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
