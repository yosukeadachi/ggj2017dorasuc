﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTreatureBox : MonoBehaviour {

	Animator m_animator;


	// Use this for initialization
	void Start () {
		m_animator = GetComponent<Animator>();
	}

	///*
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
	}
	//*/
	public void Open()
	{
		m_animator.SetBool("isOpen", true);

		StartCoroutine(AnimWait());
	}

	IEnumerator AnimWait()
	{
		yield return new WaitForSeconds(1.1f);
		

	}

	public void Close()
	{
		m_animator.SetBool("isOpen", false);
	}
}