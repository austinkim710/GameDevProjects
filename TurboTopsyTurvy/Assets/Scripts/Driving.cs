using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

enum CarState { PAUSED, MOVING};

public class Driving : MonoBehaviour {

	private InputDevice joystick = InputManager.ActiveDevice;
	private Rigidbody rb;

	//public Transform centerOfGravity;


	private float v;

	private Vector3 initPos;

	public float forwardForce, turnForce, brakeForce;
	public WheelCollider frontLeftWheel, frontRightWheel, backLeftWheel, backRightWheel;


	//private CarState state = CarState.PAUSED;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		//rb.centerOfMass = centerOfGravity.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
		/*
		if (joystick.RightTrigger.WasPressed)
		{
			v = forwardForce * 20;	
		}
		*/
		float v = Input.GetAxis("Vertical") * forwardForce; // joystick.RightTrigger * forwardForce;
		float h = Input.GetAxis("Horizontal") * turnForce; // joystick.LeftStickX * turnForce;

		backLeftWheel.motorTorque = v;
		backRightWheel.motorTorque = v;

		frontLeftWheel.steerAngle = h;
		frontRightWheel.steerAngle = h;

		if (joystick.LeftTrigger.WasPressed || Input.GetKey(KeyCode.Space))
		{
			backRightWheel.brakeTorque = brakeForce;
			backLeftWheel.brakeTorque = brakeForce;
		}
		if (joystick.LeftTrigger.WasReleased || Input.GetKeyUp(KeyCode.Space))
		{
			backLeftWheel.brakeTorque = 0;
			backRightWheel.brakeTorque = 0;
		}
		if (Input.GetAxis("Vertical") == 0 || joystick.RightTrigger.WasReleased)
		{
			backRightWheel.brakeTorque = brakeForce;
			backLeftWheel.brakeTorque = brakeForce;
			frontLeftWheel.brakeTorque = brakeForce;
			frontRightWheel.brakeTorque = brakeForce;
		}
		else
		{
			backLeftWheel.brakeTorque = 0;
			backRightWheel.brakeTorque = 0;
			frontRightWheel.brakeTorque = 0;
			frontLeftWheel.brakeTorque = 0;
		}

	}
	private void OnTriggerEnter(Collider other)
	{
		backLeftWheel.brakeTorque = 0;
		backRightWheel.brakeTorque = 0;
	}

}
