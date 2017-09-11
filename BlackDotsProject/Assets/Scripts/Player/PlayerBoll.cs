using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoll : MonoBehaviour 
{
	public delegate void BadMoveHandler();
	public static event BadMoveHandler OnBadMove;

	private Transform _currentTransform;

	void OnEnable()
	{
		_currentTransform.position = Vector3.zero;
		_currentTransform.rotation = Quaternion.identity;
	}
		
	void Awake () 
	{
		_currentTransform = transform;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == ConstantTagName.PLAYER_BOLL_TAG) 
		{
			if (OnBadMove != null)
				OnBadMove ();
		}
	}
}
