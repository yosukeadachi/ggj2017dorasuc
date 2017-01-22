using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndStage : MonoBehaviour {

    public ConfirmStage titleObj;
	public SuccessCheckerBase checkerObj;
	public GameObject doorGameObj;

	enum TimeStatus {
		InGame,
		End,
	};
	TimeStatus timeStatus = TimeStatus.InGame;
	float gameTimeCounter = 0;
	public const float GAEME_TIME_OUT_SECONDS = 10.0f;


	// Use this for initialization
	void Start () {
		timeStatus = TimeStatus.InGame;
		gameTimeCounter = 0;	//memo: ０リセットトリガーは別でもたないとだめかも
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
				StageResultManager.FaileStage(gameObject.name);
                SteamVR_Fade.Start(Color.black, 1.0f);
                Invoke("toTitleScene", 2.0f);
            }
			else if(isSuccessEscape()) {
				StageResultManager.SuccessStage(gameObject.name);
				timeStatus = TimeStatus.End;
				doorGameObj.GetComponent<Animator>().SetTrigger("OpenDoor");
                Invoke("toOk", 2.0f);
            }
            break;
		case TimeStatus.End:
            break;
		default:
			break;
		}
	}

    void toOk()
    {
        SteamVR_Fade.Start(Color.white, 1.0f);
        Invoke("toTitleScene", 2.0f);
    }

    void toTitleScene()
    {
        SceneManager.LoadScene("Title");
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
