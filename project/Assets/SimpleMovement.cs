using UnityEngine;
using System.Collections;

public class SimpleMovement : MonoBehaviour {

	public float movementSpeed = 1.0f;
	
	public float jumpSpeed = 1.0f;
	private bool isJumping = false;
	public float maxZ = 32.0f;
	public float minZ = 32.0f;
	private float zPosition = 0.0f;
	private bool isGrounded = true;
	private bool isFalling = false;

	private Animator anim;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponentInChildren<Animator> ();
		sprite = gameObject.GetComponentInChildren<SpriteRenderer> ();
	}

	private void handleJump() {
		if (Input.GetButtonDown ("Jump"))
						Debug.Log ("Jump button presses");	

		if (Input.GetButton ("Jump") && zPosition == 0.0) {
			jumpSpeed = Mathf.Abs(jumpSpeed);
			isJumping = true;
			collider2D.isTrigger = true;
		}
		
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

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Platform")
			isGrounded = true;
	}

	void OnCollisionExit2D(Collision2D coll) {
		if (coll.gameObject.tag == "Platform")
			isGrounded = false;
	}

	void Update() {
		// offset sprite by jump hight
		Vector3 position = sprite.transform.localPosition;
		position.y = zPosition;
		sprite.transform.localPosition = position;

		if (zPosition == 0.0f && !isGrounded) {
			this.enabled = false;
			isFalling = true;
		}

		if (isFalling) {
			zPosition -= Mathf.Abs(jumpSpeed);
			if(zPosition <= minZ);

		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {			
		float inputX = Mathf.Abs(Input.GetAxis ("Horizontal")) > 0.01 ? Input.GetAxis ("Horizontal") : 0;
		float inputY = Mathf.Abs(Input.GetAxis ("Vertical")) > 0.01 ? Input.GetAxis ("Vertical") : 0;

		anim.SetFloat ("xVelocity", inputX);
		anim.SetFloat ("yVelocity", inputY);
		rigidbody2D.velocity = new Vector3 (inputX * movementSpeed, inputY * movementSpeed);

		handleJump ();
	}
}
