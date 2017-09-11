using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour 
{
	private Dictionary<int,Queue<PoolObject>> _poolDictionary;

	private Transform _currentTransform;

	private static PoolManager _instance;
	public static PoolManager Instance
	{
		get 
		{
			if (_instance == null) 
				_instance = GameObject.FindObjectOfType<PoolManager> ();
			return _instance;
		}

		private set 
		{
			_instance = value;
		}
	}

	void Awake()
	{
		_currentTransform = transform;
		_poolDictionary = new Dictionary<int,Queue<PoolObject>> ();

	}

	public void CreatePool(GameObject prefab, int poolSize)
	{
		int poolKey = prefab.GetInstanceID ();

		if (!_poolDictionary.ContainsKey (poolKey)) 
		{
			_poolDictionary.Add (poolKey, new Queue<PoolObject> ());

			for (int i = 0; i < poolSize; i++) 
			{
				PoolObject newObject = Instantiate (prefab).GetComponent<PoolObject>();
				newObject.Deactivate (_currentTransform);

				_poolDictionary [poolKey].Enqueue (newObject);
			}
		}
	}

	public void ReuseFromPool(GameObject gameObj, Vector3 position, Quaternion rotation)
	{
		int poolKey = gameObj.GetInstanceID ();

		if (_poolDictionary.ContainsKey (poolKey)) 
		{
			PoolObject objectGet = _poolDictionary [poolKey].Dequeue ();
			objectGet.Activate (position, rotation);

			_poolDictionary [poolKey].Enqueue (objectGet);
		}
	}

	public void DeactivateAllPoolObjects(GameObject poolObj)
	{
		int poolKey = poolObj.GetInstanceID ();

		if (_poolDictionary.ContainsKey (poolKey)) 
		{
			int poolSize = _poolDictionary [poolKey].Count;
			for (int i = 0; i < poolSize; i++) 
			{
				PoolObject objectGet = _poolDictionary [poolKey].Dequeue ();
				objectGet.Deactivate (_currentTransform);

				_poolDictionary [poolKey].Enqueue (objectGet);
			}
		}
	}
}
