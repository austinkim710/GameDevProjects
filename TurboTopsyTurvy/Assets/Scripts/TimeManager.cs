using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float timeLeft;
	public static int minutes;
	public static int seconds;

	public GameObject minutesBox;
	public GameObject secondsBox;


	void Update()
	{
		timeLeft -= Time.deltaTime;
		if(timeLeft > 0)
		{
			secondsBox.GetComponent<Text>().text = "" + (int)timeLeft;
		}
	}

}
