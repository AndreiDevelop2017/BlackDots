using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
	//TODO: сделать сохранение счета, использовать TextMeshPro и отдельный Canvas
	private Text _currentText;
	private int _score;

	void OnEnable()
	{
		PlayerSpear.OnGoodMove += ChangeScore;
	}

	void OnDisable()
	{
		PlayerSpear.OnGoodMove -= ChangeScore;
	}

	void Awake()
	{
		_currentText = GetComponent<Text> ();
		_score = 0;
	}

	void ChangeScore()
	{
		_score++;
		_currentText.text = _score.ToString ();
	}
}
