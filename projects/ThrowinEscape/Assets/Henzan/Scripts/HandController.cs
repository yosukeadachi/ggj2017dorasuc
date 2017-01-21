using UnityEngine;
using System.Collections;

public class HandController : MonoBehaviour
{
	SteamVR_TrackedController trackedController;
	SteamVR_Controller.Device device;

	Item m_myGrabItem;
	Transform m_itemOriginTransform = null;

	bool m_isGrab = false;

	/// <summary>
	/// もう片方の手
	/// </summary>
	public HandController m_otherHand; 

	/// <summary>
	/// 持っているかどうか
	/// </summary>
	public bool IsGrab { get { return m_isGrab; } }

	/// <summary>
	/// 現在持っているItemを返す
	/// </summary>
	public Item grabItem { get { return m_myGrabItem; } }

	// Use this for initialization
	void Awake()
	{
		if (trackedController == null)
		{
			trackedController = gameObject.AddComponent<SteamVR_TrackedController>();
		}

	}

	// Update is called once per frame
	void Update()
	{
		device = SteamVR_Controller.Input((int)trackedController.controllerIndex);

		if (m_isGrab && device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
		{
			m_myGrabItem.GetComponent<Rigidbody>().velocity = device.velocity;
			m_myGrabItem.GetComponent<Rigidbody>().angularVelocity = device.angularVelocity;
			m_myGrabItem.GetComponent<Rigidbody>().isKinematic = false;
			m_myGrabItem.transform.SetParent(m_itemOriginTransform);//
			m_myGrabItem.Release();
			m_isGrab = false;
			m_myGrabItem = null;
		}

		/*
		if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
		{
			Debug.Log("open");
		}
		else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
		{
			Debug.Log("close");
		}
		*/
	}

	public void ForceRelease()
	{
		m_isGrab = false;
		m_myGrabItem = null;
	}

	// 持っているもののすり替え
	public void ChangeGrab(Item item)
	{
		if (m_isGrab)
		{
			m_myGrabItem.Release();
			item.Grab(this);
			m_isGrab = true;
			
			m_myGrabItem = item;
			m_itemOriginTransform = item.transform;

			//rigidbody呼び出して重力を消す
			item.GetComponent<Rigidbody>().isKinematic = true;
			//触っている相手（other）を自分の子にする。
			item.transform.SetParent(gameObject.transform);
		}
	}

	void OnTriggerStay(Collider other)
	{
		Item hitItem = other.gameObject.GetComponent<Item>();
		if (hitItem == null || hitItem.canGrab == false)
		{
			return;
		}

		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && !m_isGrab)
		{
			if (m_otherHand.grabItem == hitItem)
			{
				m_otherHand.ForceRelease();
				m_itemOriginTransform = m_otherHand.m_itemOriginTransform;
			}

			hitItem.Grab(this);
			m_isGrab = true;
			m_myGrabItem = hitItem;
			m_itemOriginTransform = hitItem.transform;

			//rigidbody呼び出して重力を消す
			other.GetComponent<Rigidbody>().isKinematic = true;
			//触っている相手（other）を自分の子にする。
			other.transform.SetParent(gameObject.transform);
		}
	}
}