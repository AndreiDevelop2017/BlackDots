using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour, IMove 
{
	private Transform _currentTransform;
	// Use this for initialization
	void OnEnable()
	{
		PlayerSpear.OnGoodMove += StopMove;
		PlayerBoll.OnBadMove += StopMove;
	}

	void OnDisable()
	{
		PlayerSpear.OnGoodMove -= StopMove;
		PlayerBoll.OnBadMove -= StopMove;
	}

	void Awake () 
	{
		_currentTransform = transform;
	}
	
	// Update is called once per frame
	public void MoveForward(float endPoint, float speed)
	{
		_currentTransform.DOMoveY (endPoint, speed).SetEase(Ease.Linear);
	}

	public void StopMove()
	{
		_currentTransform.DOKill ();
	}
}
