using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour 
{
	private Dictionary<int,Queue<PoolObject>> _poolDictionary = new Dictionary<int,Queue<PoolObject>>();

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

	public void CreatePool(GameObject prefab, int poolSize)
	{
		int poolKey = prefab.GetInstanceID ();

		if (!_poolDictionary.ContainsKey (poolKey)) 
		{
			_poolDictionary.Add (poolKey, new Queue<PoolObject> ());

			for (int i = 0; i < poolSize; i++) 
			{
				PoolObject newObject = Instantiate (prefab).GetComponent<PoolObject>();
				_poolDictionary [poolKey].Enqueue (newObject);
			}
		}
	}

	public void GetFromPool(GameObject gameObj, Vector3 position, Quaternion rotation)
	{
		int poolKey = gameObj.GetInstanceID ();

		if (_poolDictionary.ContainsKey (poolKey)) 
		{
			PoolObject objectGet = _poolDictionary [poolKey].Dequeue ();
			objectGet.Activate (position, rotation);
		}
	}

	public void PutToPool(PoolObject poolObj)
	{
		int poolKey = poolObj.gameObject.GetInstanceID ();

		if (_poolDictionary.ContainsKey (poolKey)) 
		{
			poolObj.Deactivate ();
			_poolDictionary [poolKey].Enqueue (poolObj);
		}
	}
}
