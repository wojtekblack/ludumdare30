using UnityEngine;
using System.Collections;

public class ParalaxingBackground : MonoBehaviour {

	public Transform[] paralaxingElements;
	public float paralaxSpeed = 1.0f;
	private float screenWidth;

	// Use this for initialization
	void Start () {
		screenWidth = Camera.main.pixelWidth / 2;
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Transform trans in paralaxingElements) {
			Vector3 tempPosition = trans.localPosition;
			tempPosition.x += paralaxSpeed * Time.deltaTime;
			if(tempPosition.x >= screenWidth)
				tempPosition.x = -screenWidth;
			trans.localPosition = tempPosition;
		}
	}
}
