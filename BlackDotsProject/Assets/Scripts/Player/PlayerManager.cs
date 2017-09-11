using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
	private const float PLAYER_DURATION_MOVE_TO_AIM = 0.5f;

	private Transform _aimBollTransform;

	private PlayerMove _playerBoll;
	private Transform _currentTransform;

	private SpriteRenderer _spearSprite;
	private bool _enablePlayManager;
	void OnEnable()
	{
		SensorController.OnSensorPress += MovePlayer;
		PlayerSpear.OnGoodMove += GoodMoveAction;

		ResetValues();
	}

	void OnDisable()
	{
		SensorController.OnSensorPress -= MovePlayer;
		PlayerSpear.OnGoodMove -= GoodMoveAction;
	}
	// Use this for initialization
	void Awake () 
	{
		_currentTransform = transform;
		_spearSprite = _currentTransform.GetChild (0).GetComponent<SpriteRenderer>();
		_playerBoll = GetComponent<PlayerMove> ();	
		_aimBollTransform = GameObject.FindWithTag (ConstantTagName.AIM_BOLL_TAG).GetComponent<Transform>();
		_enablePlayManager = true;
	}

	void MovePlayer () 
	{
		if(_enablePlayManager)
			_playerBoll.MoveForward (_aimBollTransform.position.y, PLAYER_DURATION_MOVE_TO_AIM);
	}

	void GoodMoveAction()
	{
		_currentTransform.SetParent (_aimBollTransform);
		_spearSprite.enabled = true;

		_playerBoll.StopMove ();
		_enablePlayManager = false;
	}

	void ResetValues()
	{
		_spearSprite.enabled = false;

		_playerBoll.StopMove ();
		_enablePlayManager = true;
	}
}
