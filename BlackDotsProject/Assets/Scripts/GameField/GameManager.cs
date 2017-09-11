using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	private const int PLAYER_BOLL_COUNT = 20;

	public delegate void LoseGameHandler ();
	public static LoseGameHandler OnLoseGame;

	public GameObject playerBollPrefab;

	//private Vector3 _firstPlayerBollPosition = new Vector3 (0f, -3.5f, 0f);
	private Vector3 _secondPlayerBollPosition = new Vector3 (0f, -4.5f, 0f);
	//private Vector3 _thirdPlayerBollPosition = new Vector3 (0f, -5.5f, 0f);

	//private PlayerBollManager[] _playerBollManagers;
	void OnEnable()
	{
		PlayerSpear.OnGoodMove += SetNewPlayerBoll;
		PlayerBoll.OnBadMove += ReloadLevel;
	}

	void OnDisable()
	{
		PlayerSpear.OnGoodMove -= SetNewPlayerBoll;
		PlayerBoll.OnBadMove -= ReloadLevel;
	}
	// Use this for initialization
	void Start () 
	{
		PoolManager.Instance.CreatePool (playerBollPrefab, PLAYER_BOLL_COUNT);

		//PoolManager.Instance.GetFromPool (playerBollPrefab, _firstPlayerBollPosition, Quaternion.identity);
		PoolManager.Instance.ReuseFromPool (playerBollPrefab, _secondPlayerBollPosition, Quaternion.identity);
		//PoolManager.Instance.GetFromPool (playerBollPrefab, _thirdPlayerBollPosition, Quaternion.identity);

		//_playerBollManagers = GameObject.FindObjectsOfType<PlayerBollManager> ();
	}
	
	void SetNewPlayerBoll()
	{
		PoolManager.Instance.ReuseFromPool (playerBollPrefab, _secondPlayerBollPosition, Quaternion.identity);
	}

	//TODO: прописать нормальное переключение уровней с анимацией

	void ReloadLevel()
	{
		PoolManager.Instance.DeactivateAllPoolObjects (playerBollPrefab);

		if (OnLoseGame != null)
			OnLoseGame ();

		PoolManager.Instance.ReuseFromPool (playerBollPrefab, _secondPlayerBollPosition, Quaternion.identity);
	}
}
