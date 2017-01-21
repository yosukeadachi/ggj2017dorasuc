using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageResultManager : MonoBehaviour {

	static Dictionary<string, bool> stageResults = new Dictionary<string, bool> () {
		{"Stage1", false},
		{"Stage2", false}
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
		setStageResult(aStageName, false);
	}

	//ステージクリア情報保存
	static void setStageResult(string aStageName , bool aIsSuccess) {
		if(stageResults.ContainsKey(aStageName)) {
			stageResults[aStageName] = aIsSuccess;
		}
	}
		
}
