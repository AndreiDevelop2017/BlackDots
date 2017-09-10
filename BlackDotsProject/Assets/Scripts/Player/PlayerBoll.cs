using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoll : MonoBehaviour 
{
	public delegate void BadMoveHandler();
	public static event BadMoveHandler OnBadMove;

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == ConstantTagName.PLAYER_BOLL_TAG) 
		{
			if (OnBadMove != null)
				OnBadMove ();
		}
	}
}
