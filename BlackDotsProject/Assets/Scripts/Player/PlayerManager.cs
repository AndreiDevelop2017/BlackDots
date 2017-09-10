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

	void OnEnable()
	{
		SensorController.OnSensorPress += MovePlayer;
		PlayerBoll.OnBadMove += BadMoveAction;
		PlayerSpear.OnGoodMove += GoodMoveAction;
	}

	void OnDisable()
	{
		SensorController.OnSensorPress -= MovePlayer;
		PlayerBoll.OnBadMove -= BadMoveAction;
		PlayerSpear.OnGoodMove -= GoodMoveAction;
	}
	// Use this for initialization
	void Awake () 
	{
		_currentTransform = transform;
		_spearSprite = _currentTransform.GetChild (0).GetComponent<SpriteRenderer>();
		_playerBoll = GetComponent<PlayerMove> ();	
		_aimBollTransform = GameObject.FindWithTag (ConstantTagName.AIM_BOLL_TAG).GetComponent<Transform>();
	}

	void MovePlayer () 
	{
		_playerBoll.MoveForward (_aimBollTransform.position.y, PLAYER_DURATION_MOVE_TO_AIM);
	}

	void GoodMoveAction()
	{
		_currentTransform.SetParent (_aimBollTransform);
		_spearSprite.enabled = true;
		this.enabled = false;
	}

	void BadMoveAction()
	{
		_currentTransform.SetParent (null);
		_spearSprite.enabled = false;
		this.enabled = false;
	}
}
