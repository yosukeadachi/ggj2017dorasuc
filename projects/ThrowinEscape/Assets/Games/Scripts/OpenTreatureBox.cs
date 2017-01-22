using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OpenTreatureBox : MonoBehaviour {

	public GameObject roomObj;
	public GameObject floor1Obj;
	public GameObject floor2Obj;
	public float fallSpeed;
	bool isFallen;

	Animator m_animator;

	// Use this for initialization
	void Start () {
		m_animator = GetComponent<Animator>();
		isFallen = false;
		Open();//Debug

	}

	void Update() {
		if(isFallen) {
			var vel = Vector3.zero;
			vel.y = fallSpeed;
			roomObj.transform.position += vel;
		}
	}

	/*
	float timer = 0f;	
	// Update is called once per frame
	void Update () {
		Debug.Log(m_animator.GetCurrentAnimatorStateInfo(0).length);
		timer += Time.deltaTime;

		if(timer > 4f)
		{
			m_animator.SetBool("isOpen", true);
			timer = 0f;
		}else if(timer > 2f)
		{
			m_animator.SetBool("isOpen", false);

		}

		if (Input.GetMouseButton(0))
		{
			Open();
		}

	}
	//*/
	public void Open()
	{
		m_animator.SetBool("isOpen", true);

		SteamVR_Fade.Start(Color.white, 3.0f);
		floor1Obj.GetComponent<Animator>().SetTrigger("DoOpenFloor1");
		floor2Obj.GetComponent<Animator>().SetTrigger("DoOpenFloor2");
		isFallen = true;
		Invoke("StartStageBalloon",3.0f);
	}

	void StartStageBalloon()
	{
		SceneManager.LoadScene("StageBalloon");
	}

	public void Close()
	{
		m_animator.SetBool("isOpen", false);
	}
}
