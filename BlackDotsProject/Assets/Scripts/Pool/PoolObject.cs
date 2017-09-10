using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour {

	private Transform _currentTransform;
	private GameObject _currentGameObject;

	void Awake()
	{
		_currentGameObject = gameObject;
		_currentTransform = _currentGameObject.transform;
		Deactivate ();
	}

	public void Activate(Vector3 position, Quaternion rotation)
	{
		_currentGameObject.SetActive (true);
		_currentTransform.position = position;
		_currentTransform.rotation = rotation;
	}

	public void Deactivate()
	{
		_currentGameObject.SetActive (false);
		_currentTransform.position = Vector3.zero;
		_currentTransform.rotation = Quaternion.identity;
	}
}
