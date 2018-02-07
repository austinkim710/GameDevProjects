using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfLapTrigger : MonoBehaviour {

	public GameObject LapComplete;
	public GameObject HalfLapComplete;

	// Use this for initialization
	void OnTriggerEnter()
	{
		HalfLapComplete.SetActive(false);
		LapComplete.SetActive(true);
	}
}
