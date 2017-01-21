using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageResultManager : MonoBehaviour {

	static Dictionary<string, bool> stageResults = new Dictionary<string, bool> () {
		{"StageBalloon", false},
	};
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//ステージ成功
	public static void SuccessStage(string aStageName) {
		setStageResult(aStageName, true);
	}

	//ステージ失敗
	public static void FaileStage(string aStageName) {
		//一度クリアしたステージは失敗してもなにもしない
		if(getStageResult(aStageName) == false) {
			setStageResult(aStageName, false);
		}
	}

	//ステージクリア情報保存
	static void setStageResult(string aStageName , bool aIsSuccess) {
		if(stageResults.ContainsKey(aStageName)) {
			stageResults[aStageName] = aIsSuccess;
		}
	}

	//ステージクリア情報取得
	static bool getStageResult(string aStageName) {
		if(stageResults.ContainsKey(aStageName)) {
			return stageResults[aStageName];
		}
		return false;
	}
		
}
