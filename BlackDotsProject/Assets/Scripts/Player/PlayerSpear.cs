using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpear : MonoBehaviour 
{
	public delegate void GoodMoveHandler();
	public static event GoodMoveHandler OnGoodMove;

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == ConstantTagName.AIM_BOLL_TAG) 
		{
			if (OnGoodMove != null)
				OnGoodMove ();
		}
	}
}
