using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugConfirmStage : MonoBehaviour {

	public ConfirmStage csObj;
	float timeCounter = 0;

	// Use this for initialization
	void Start () {
		timeCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime;
		if(timeCounter > 3.0f) {
			csObj.Confirm();
		}
	}
}
