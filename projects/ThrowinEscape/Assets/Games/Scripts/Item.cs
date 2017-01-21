using UnityEngine;
using System.Collections;

[RequireComponent( typeof(Rigidbody) )]
public class Item : MonoBehaviour
{
	bool m_grabbed = false;
	
	HandController grabbedHand;
	
	Rigidbody m_rig;
	public bool canGrab = true;

	public bool isGrab { get { return m_grabbed; } }

	void Awake()
	{
		m_rig = GetComponent<Rigidbody>();
		if (m_rig == null) Debug.LogError("ItemにRgidbodyがついてません");

	}

	void Start()
	{

	}

	void Update()
	{
		

		// 遠くに行ったら消す
		if (transform.position.magnitude > 20f)
		{
			Destroy(gameObject);
		}
	}

	/*void FixedUpdate()
	{

	}*/

	/// <summary>
	/// 掴む
	/// </summary>
	/// <param name="hand"></param>
	public void Grab(HandController hand)
	{
		m_grabbed = true;
		grabbedHand = hand;
	}

	/// <summary>
	/// 放す
	/// </summary>
	public void Release()
	{
		m_grabbed = false;
		grabbedHand = null;
	}
}