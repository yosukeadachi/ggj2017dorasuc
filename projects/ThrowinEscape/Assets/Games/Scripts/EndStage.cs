using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStage : MonoBehaviour {

	public ConfirmStage titleCsObj;
	public SuccessCheckerBase checkerObj;
	public GameObject doorGameObj;


	enum TimeStatus {
		InGame,
		End,
	};
	TimeStatus timeStatus = TimeStatus.InGame;
	float gameTimeCounter = 0;
	public const float GAEME_TIME_OUT_SECONDS = 10.0f;
	float endEffectTimeCounter = 0;
	public const float END_EFFECT_TIME_OUT_SECONDS = 10.0f;


	// Use this for initialization
	void Start () {
		timeStatus = TimeStatus.InGame;
		gameTimeCounter = 0;	//memo: ０リセットトリガーは別でもたないとだめかも
		endEffectTimeCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		updateTimer();
		checkEnd();
	}

	//タイマーカウントアップ
	void updateTimer() {
		switch(timeStatus) {
		case TimeStatus.InGame:
			gameTimeCounter += Time.deltaTime;
			break;
		case TimeStatus.End:
			endEffectTimeCounter += Time.deltaTime;
			break;
		default:
			break;
		}
	}

	//終了チェック
	void checkEnd() {
		switch(timeStatus) {
		case TimeStatus.InGame:
			if(isGameTimeOver()) {
//				doorGameObj.GetComponent<Animator>().SetTrigger("OpenDoor");
				StageResultManager.FaileStage(gameObject.name);
				titleCsObj.Confirm();
			}
			else if(isSuccessEscape()) {
				StageResultManager.SuccessStage(gameObject.name);
				timeStatus = TimeStatus.End;
				doorGameObj.GetComponent<Animator>().SetTrigger("OpenDoor");
			}
			break;
		case TimeStatus.End:
			if(endEffectTimeCounter > END_EFFECT_TIME_OUT_SECONDS) {
				titleCsObj.Confirm();
			}
			break;
		default:
			break;
		}
	}

	//ゲーム時間オーバー
	bool isGameTimeOver() {
//		Debug.Log("time " + timeCounter);
		return (gameTimeCounter > GAEME_TIME_OUT_SECONDS);
	}

	//脱出成功
	bool isSuccessEscape() {
		return checkerObj.isSuccess();
	}
}
