using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBollManager : MonoBehaviour 
{
	private const float PLAYER_DURATION_MOVE_TO_AIM = 2f;

	public delegate void PlayerMoveGoodMoveHandler();
	public static event PlayerMoveGoodMoveHandler OnGoodMove;

	public delegate void PlayerMoveBadMoveHandler();
	public static event PlayerMoveBadMoveHandler OnBadMove;

	private Transform _aimBollTransform;

	private PlayerBollMove _playerBoll;
	private Transform _currentTransform;

	void OnEnable()
	{
		SensorController.OnSensorPress += MovePlayer;
	}

	void OnDisable()
	{
		SensorController.OnSensorPress -= MovePlayer;
	}
	// Use this for initialization
	void Start () 
	{
		_currentTransform = transform;
		_playerBoll = GetComponent<PlayerBollMove> ();	
		_aimBollTransform = GameObject.FindWithTag (ConstantTagName.AIM_BOLL_TAG).GetComponent<Transform>();
	}

	void MovePlayer () 
	{
		_playerBoll.MoveForward (_aimBollTransform.position.y, PLAYER_DURATION_MOVE_TO_AIM);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == ConstantTagName.AIM_BOLL_TAG) 
		{
			_currentTransform.SetParent (_aimBollTransform);

			if (OnGoodMove != null)
				OnGoodMove ();
		}

		if (col.gameObject.tag == ConstantTagName.PLAYER_BOLL_TAG) 
		{
			if (OnBadMove != null)
				OnBadMove ();
		}

		this.enabled = false;
	}
}
