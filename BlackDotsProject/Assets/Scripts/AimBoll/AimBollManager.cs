﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AimBollManager : MonoBehaviour 
{
	private bool _IsRotating;
	private Transform _currentTransform;
	// Use this for initialization
	void OnEnable()
	{
		PlayerBollManager.OnGoodMove += StartRotate;
		PlayerBollManager.OnBadMove += StopRotate;
	}

	void OnDisable()
	{
		PlayerBollManager.OnGoodMove -= StartRotate;
		PlayerBollManager.OnBadMove -= StopRotate;
	}

	void Awake () 
	{
		_currentTransform = transform;	
	}
	
	// Update is called once per frame
	void StartRotate()
	{
		if (!_IsRotating) 
		{
			_currentTransform.DORotate (new Vector3 (0f, 0f, 360f), 5f, RotateMode.FastBeyond360).SetEase (Ease.Linear).SetLoops (-1);
			_IsRotating = true;
		}
	}

	void StopRotate()
	{
		_currentTransform.DOKill();
		_IsRotating = false;
	}
}