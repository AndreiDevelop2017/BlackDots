using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMove : MonoBehaviour, IMove 
{
	private Transform _currentTransform;

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
