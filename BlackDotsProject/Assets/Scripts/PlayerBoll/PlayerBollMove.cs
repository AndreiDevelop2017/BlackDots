using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerBollMove : MonoBehaviour, IMove 
{
	private Transform _currentTransform;
	// Use this for initialization
	void OnEnable()
	{
		PlayerBollManager.OnGoodMove += StopMove;
		PlayerBollManager.OnBadMove += StopMove;
	}

	void OnDisable()
	{
		PlayerBollManager.OnGoodMove -= StopMove;
		PlayerBollManager.OnBadMove -= StopMove;
	}

	void Awake () 
	{
		_currentTransform = transform;
	}
	
	// Update is called once per frame
	public void MoveForward(float endPoint, float speed)
	{
		_currentTransform.DOMoveY (endPoint, speed);
	}

	public void StopMove()
	{
		_currentTransform.DOKill ();
	}
}
