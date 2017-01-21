using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRingCollider : MonoBehaviour {

	bool m_isHit = false;
	public bool IsHit { get { return m_isHit; } }

	public string m_hitTag;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerExit(Collider other)
	{
		Debug.Log(other.gameObject.tag);
		if (m_hitTag == other.gameObject.tag)
		{
			ConfirmStage confirm = other.gameObject.GetComponent<ConfirmStage>();
			if (confirm == null)
			{
				Debug.LogError("投げたものにConfirmがついてないよ！");
				return;
			}
			m_isHit = true;
		}
	}

}
