using UnityEngine;
using System;
using System.Collections;

public class SimpleMovement : MonoBehaviour {

	public float movementSpeed = 1.0f;
	
	public float jumpSpeed = 1.0f;
	private bool isJumping = false;
	public float maxZ = 32.0f;
	public float minZ = -32.0f;
	private float zPosition = 0.0f;
	private bool isGrounded = true;
	private bool isFalling = false;
	public EventHandler eventHandler;
	public GameObject shadow;

	private Animator anim;
	private SpriteRenderer sprite;
	private AudioSource jumpSound;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponentInChildren<Animator> ();
		sprite = gameObject.GetComponentInChildren<SpriteRenderer> ();
		jumpSound = gameObject.GetComponent<AudioSource> ();
	}

	private void handleJump() {

		if (Input.GetButton ("Jump") && zPosition == 0.0) {
			jumpSound.Play();
			jumpSpeed = Mathf.Abs(jumpSpeed);
			isJumping = true;
			collider2D.isTrigger = true;
		}

		anim.SetBool ("isJumping", isJumping);
		
		if (isJumping)
			zPosition += jumpSpeed;
		
		if (zPosition >= maxZ)
			jumpSpeed = -jumpSpeed;
		else if (zPosition <= 0.0) {
			isJumping = false;
			zPosition = 0.0f;
			collider2D.isTrigger = false;
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Platform") {
			isGrounded = true;
			transform.parent = coll.transform;
			shadow.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag == "Platform") {
			isGrounded = false;
			transform.parent = null;
			shadow.SetActive(false);
		}
	}

	void Update() {
		// offset sprite by jump hight
		Vector3 position = sprite.transform.localPosition;

		if (zPosition == 0.0f && !isGrounded) {
			rigidbody2D.velocity = Vector3.zero;
			isFalling = true;
			sprite.sortingOrder = 4;
		}

		if (isFalling) {
			zPosition -= Mathf.Abs(jumpSpeed);	
			if(zPosition <= minZ) {
				eventHandler.OnGameOver(EventArgs.Empty);
				gameObject.SetActive(false);
			}
		}

		position.y = zPosition;
		sprite.transform.localPosition = position;
		anim.SetFloat ("zPosition", zPosition);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!isFalling) {
			float inputX = Mathf.Abs (Input.GetAxis ("Horizontal")) > 0.01 ? Input.GetAxis ("Horizontal") : 0;
			float inputY = Mathf.Abs (Input.GetAxis ("Vertical")) > 0.01 ? Input.GetAxis ("Vertical") : 0;

			anim.SetFloat ("xVelocity", inputX);
			anim.SetFloat ("yVelocity", inputY);
			rigidbody2D.velocity = new Vector3 (inputX * movementSpeed, inputY * movementSpeed);

			handleJump ();
		}
	}
}
