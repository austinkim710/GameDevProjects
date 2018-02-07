using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour {

	public GameObject LapCompleteTrigger;
	public GameObject HalfLapTrigger;

	public GameObject LapTimeBox;

	void OnTriggerEnter()
	{
		HalfLapTrigger.SetActive(true);
		LapCompleteTrigger.SetActive(false);
		LapTimeBox.GetComponent<Text>().text = "Finished!";
	}

}
