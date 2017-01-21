using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessCheckerBase : MonoBehaviour {

	protected int counter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//成功判定
	//overrideして使うこと
	public virtual bool isSuccess() {
		return false;
	}

	//回数カウント
	public virtual void addCount() {
		counter += 1;
	}

}