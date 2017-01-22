using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGateManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos3 = transform.position;
		newPos3.y += 0.005f;
		transform.position = newPos3;
	}
}
