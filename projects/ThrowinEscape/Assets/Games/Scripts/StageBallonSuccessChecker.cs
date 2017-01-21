using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBallonSuccessChecker : SuccessCheckerBase {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//風船ステージの成功条件
	public override bool isSuccess() {
		return (counter > 2);
	}
}
