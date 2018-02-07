using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform car;
	public float distance;
	public float height;
	public float rotation;
	public float heightDamp;
	public float zoomRatio;
	public float defaultFOV;

	private float rotation_vect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 local_velocity = car.InverseTransformDirection(car.GetComponent<Rigidbody>().velocity); //worldspace to local space , position in space
		if(local_velocity.z < -0.5f)
		{
			rotation_vect = car.eulerAngles.y + 100 ;
		}
		else
		{
			rotation_vect = car.eulerAngles.y;
		}
		float acceleration = car.GetComponent<Rigidbody>().velocity.magnitude;
		Camera.main.fieldOfView = defaultFOV + acceleration * zoomRatio * Time.deltaTime;

	}

	private void LateUpdate() //follow camera should always be implemented in LateUpdate because it tracks objects that might have moved inside Update.
	{
		float wantedAngle = rotation_vect;

		float wantedHeight = car.position.y + height;
		float myAngle = transform.eulerAngles.y;
		float myHeight = transform.position.y;

		myAngle = Mathf.LerpAngle(myAngle,wantedAngle,rotation * Time.deltaTime);
		myHeight = Mathf.LerpAngle(myHeight, wantedHeight, heightDamp * Time.deltaTime);

		Quaternion currentRotation = Quaternion.Euler(0, myAngle, 0);

		transform.position = car.position;
		transform.position -= currentRotation * Vector3.forward * distance;

		Vector3 tmp = transform.position;
		tmp.y = myHeight;
		transform.position = tmp;

		transform.LookAt(car);
	}

}
