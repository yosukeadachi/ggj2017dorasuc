using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {
    public float speed = 0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        var vel = Vector3.zero;
        vel.y = speed;
        transform.position += vel;

    }
}
