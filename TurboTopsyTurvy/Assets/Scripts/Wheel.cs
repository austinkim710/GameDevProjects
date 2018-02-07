using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour
{

	public WheelCollider wheelC;

	private Vector3 wheelCCenter;
	private RaycastHit hit;

	void Start()
	{

	}

	void Update()
	{
		wheelCCenter = wheelC.transform.TransformPoint(wheelC.center);

		if (Physics.Raycast(wheelCCenter, -wheelC.transform.up, out hit, wheelC.suspensionDistance + wheelC.radius))
		{
			transform.position = hit.point + (wheelC.transform.up * wheelC.radius);
		}
		else
		{
			transform.position = wheelCCenter - (wheelC.transform.up * wheelC.suspensionDistance);
		}
	}

	void FixedUpdate()
	{

	}
}
