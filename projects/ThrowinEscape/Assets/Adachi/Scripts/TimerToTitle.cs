using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TimerToTitle : MonoBehaviour {

	float timeCounter = 0;
	public const float TIME_OUT_SECONDS = 3.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime;
		if(timeCounter > TIME_OUT_SECONDS) {
			SceneManager.LoadScene ("Title");
		}
	}
}
