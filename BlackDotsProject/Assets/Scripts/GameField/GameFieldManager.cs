using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFieldManager : MonoBehaviour 
{
	private const int PLAYER_BOLL_COUNT = 20;

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
		PoolManager.Instance.GetFromPool (playerBollPrefab, _secondPlayerBollPosition, Quaternion.identity);
		//PoolManager.Instance.GetFromPool (playerBollPrefab, _thirdPlayerBollPosition, Quaternion.identity);

		//_playerBollManagers = GameObject.FindObjectsOfType<PlayerBollManager> ();
	}
	
	void SetNewPlayerBoll()
	{
		PoolManager.Instance.GetFromPool (playerBollPrefab, _secondPlayerBollPosition, Quaternion.identity);
	}

	//TODO: прописать нормальное переключение уровней с анимацией

	void ReloadLevel()
	{
		StartCoroutine (LoadSceneDelay ());
	}

	IEnumerator LoadSceneDelay()
	{
		yield return new WaitForSeconds (0.05f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
