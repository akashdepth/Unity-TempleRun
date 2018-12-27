using UnityEngine;
using System.Collections;

public class TrolControl : MonoBehaviour {
	
	private Animator anim;
	private CharacterController controller;
	private bool battle_state;
	public float speed = 6.0f;
	public float runSpeed = 1.7f;
	public float turnSpeed = 60.0f;
	private float jumpSpeed = 1f;
	public float gravity = 20.0f;
	private float deathValue = -50.0f;
	private Vector2 startPos;
	private Vector3 moveDirection = Vector3.zero;


	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep; 
		anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController> ();
	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		if (hit.point.z>transform.position.z+controller.radius-0.12) {
			GetComponent<Score> ().onDeath ();
		}
		Debug.Log ("Hit z"+hit.point.z);
		Debug.Log ("Hit transform "+(transform.position.z+controller.radius));

	}
	
	void Update () {
		
		if (moveDirection.y < deathValue) {
			GetComponent<Score> ().onDeath ();
			return;
		}

		anim.SetInteger ("moving", 1);
		runSpeed += 0.0002f;

		if(controller.isGrounded)
		{
			moveDirection=transform.forward * speed * runSpeed;
			
		}

		float turn = 0.0f;
//		if (Input.GetMouseButton (0)) {
			
//			if (Input.mousePosition.x > Screen.width / 2) {
//				turn = 1;
//			} else {
//				turn = -1;
//			}

//			if (Input.mousePosition.y > Screen.height/2) {
//				moveDirection+=transform.up * jumpSpeed;
//			}
//		}

		// Track a single touch as a direction control.
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			// Handle finger movements based on TouchPhase
			switch (touch.phase)
			{
			//When a touch has first been detected, change the message and record the starting position
			case TouchPhase.Began:
				// Record initial touch position.
				startPos = touch.position;
				break;
				//Determine if the touch is a moving touch
			case TouchPhase.Moved:
				// Determine direction by comparing the current touch position with the initial one
				Vector2 direction = touch.position - startPos;
				if (direction.y > 0) {
					moveDirection += transform.up * jumpSpeed;
				}
				break;

			case TouchPhase.Ended:
				break;
			}
		}

		turn = Input.acceleration.x;



		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move(moveDirection *Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;

	}
}
