using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStage : MonoBehaviour {

	public ConfirmStage titleCsObj;
	float timeCounter = 0;
	public const float TIME_OUT_SECONDS = 10.0f;

	// Use this for initialization
	void Start () {
		timeCounter = 0;	//memo: ０リセットトリガーは別でもたないとだめかも
	}
	
	// Update is called once per frame
	void Update () {
		updateTimer();
		if(isTimeOver()) {
			StageResultManager.FaileStage(gameObject.name);
			titleCsObj.Confirm();
		}
		else if(isSuccessEscape()) {
			StageResultManager.SuccessStage(gameObject.name);
			titleCsObj.Confirm();
		}
	}

	//タイマーカウントアップ
	void updateTimer() {
		timeCounter += Time.deltaTime;
	}

	//時間オーバー
	bool isTimeOver() {
//		Debug.Log("time " + timeCounter);
		return (timeCounter > TIME_OUT_SECONDS);
	}

	//脱出成功
	//@TODO ここを変更してください
	bool isSuccessEscape() {
		return false;
	}
}
