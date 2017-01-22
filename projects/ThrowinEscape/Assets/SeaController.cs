using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaController : MonoBehaviour
{
	enum SeaStatus
	{
		UP,
		STOP,
	}

	SeaStatus m_SeaStatus = SeaStatus.UP;

	public StageBallonSuccessChecker stageBalloonSuccessChecker;

	public float speed = 0.05f;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		switch(m_SeaStatus)
		{
			case SeaStatus.UP:
				Vector3 vel = Vector3.zero;
				vel.y = speed;
				transform.position += vel;
				break;

			case SeaStatus.STOP:
				break;

			default:
				break;
		}

		if (stageBalloonSuccessChecker.isSuccess())
		{
			m_SeaStatus = SeaStatus.STOP;
		}


	}
}