using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGateManager : MonoBehaviour {

	public Balloon waterBalloonCS;

	public StageBallonSuccessChecker stageBalloonSuccessChecker;

	float upSpeed;

	[SerializeField]
	float downSpeed = 1f;


	enum GateStatus
	{
		UP,
		DOWN,
		STOP,
	}

	GateStatus m_gateStatus = GateStatus.UP;


	// Use this for initialization
	void Start () {
		upSpeed = waterBalloonCS.speed;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (m_gateStatus == GateStatus.UP)
		{

			Vector3 newPos3 = transform.position;
			newPos3.y += upSpeed;
			transform.position = newPos3;
		}
		else if(m_gateStatus == GateStatus.DOWN)
		{
			Vector3 newPos3 = transform.position;
			newPos3.y -= downSpeed * Time.deltaTime;
			transform.position = newPos3;

			if (transform.position.y < -2.5f)
			{
				m_gateStatus = GateStatus.STOP;
			}
		}

		if (stageBalloonSuccessChecker.isSuccess())
		{
			m_gateStatus = GateStatus.DOWN;
		}
	}

}
