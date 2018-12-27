using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	private CharacterController controller;
	private float speed = 15.0f;
	private Vector3 moveVector;
	private float verticalVelocity;
	private float gravity = 12.0f;
	private float animationDuration = 2.0f;


	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time < animationDuration) {
		
			controller.Move (Vector3.forward*speed*Time.deltaTime);
			return;
		}
		moveVector = Vector3.zero;

		if (controller.isGrounded) {
			verticalVelocity -= speed;

		} else {
			verticalVelocity -= gravity;
		}
			
		moveVector.y = verticalVelocity;
//		moveVector.x = Input.acceleration.x * speed;
		moveVector.z = speed;
		controller.Move (moveVector * Time.deltaTime);
	
	}
}
