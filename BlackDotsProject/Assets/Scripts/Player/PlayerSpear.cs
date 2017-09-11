using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpear : MonoBehaviour 
{
	public delegate void GoodMoveHandler();
	public static event GoodMoveHandler OnGoodMove;

	private Transform _currentTransform;
	private Vector3 _prevTransform;

	void OnEnable()
	{
		_currentTransform.position = _prevTransform;
		_currentTransform.rotation = Quaternion.identity;
	}

	void Awake () 
	{
		_currentTransform = transform;
		_prevTransform = _currentTransform.position;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == ConstantTagName.AIM_BOLL_TAG) 
		{
			if (OnGoodMove != null)
				OnGoodMove ();
		}
	}
}
